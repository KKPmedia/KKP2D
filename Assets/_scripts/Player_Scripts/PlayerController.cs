using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float startHP = 10f;
	public float MaxSpeed = 30f;
	public float run_multiplikator = 1.5f;
	public float run_timer = 10f;
	static bool FacingRight = true;
	public Transform GroundCheck;
	public LayerMask whatIsGrounded;
	public float jumpForce = 800f;
	public float climbSpeed = 5f;
	public GameObject shot;
	public Transform ShotSpawn;
	public float fireRate = 1.5f;
	public float slashRate = 1f;

	Animator anim;
	Rigidbody2D rb;
	bool grounded = false;
	float groundRadius = 0.2f;
	private bool inRun = false;
	private bool climb = false;
	private float gravity;
	private float linearDrag;
	private bool crouch = false;
	private bool alive = true;
	private float nextFire = 0.0f;
	private float nextSlash = 0.0f;
	private Vector3 resetPos;
	private float HP;
	private int i = 0;
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody2D> ();
		gravity = rb.gravityScale;
		linearDrag = rb.drag;
		resetPos = new Vector3 (this.GetComponent<Transform> ().localPosition.x, this.GetComponent<Transform> ().localPosition.y);
		HP = startHP;
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, whatIsGrounded);
		anim.SetBool ("isGrounded", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
	
		if (climb) 
			climbing ();
		else if (alive && !crouch)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * MaxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
		if (move > 0 && !FacingRight)
			Flip ();
		else if (move < 0 && FacingRight)
			Flip();
	}
	
	// Update is called once per frame
	void Update() {

		if (alive) {
			if ((grounded) && Input.GetButtonDown ("Jump") && !crouch) {
				jump ();
			}

			if (inRun) {
				run_timer -= Time.deltaTime;
				if (run_timer < 0) {
					run_timer = 0;
				}
			}
			if (!inRun) {
				run_timer += Time.deltaTime;
				if (run_timer > 10) {
					run_timer = 10;
				}
			}
			if (Input.GetButtonDown ("Run") && run_timer > 1) {
				inRun = true;
				run ();
			}
			if (Input.GetButtonUp ("Run")) {
				inRun = false;
				notRun ();
			}
			if (Input.GetButtonDown ("Crouch")) {
				m_crouch ();
			}
			if (Input.GetButtonUp ("Crouch")) {
				notCrouch ();
			}
			if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && !anim.GetBool("climb")) {
				shoot ();
			}
			if (Input.GetButtonDown("Hit") && Time.time > nextSlash) {
				slash ();
			}
		}
		
		if (HP < 1) {
			dead();
		}
	}
	
	void Flip() {
		FacingRight = !FacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;

		Vector3 position = transform.localPosition;
		if (FacingRight)
			position.x += 1;
		if (!FacingRight)
			position.x -= 1;

		transform.localPosition = position;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Ladder")) {
			float vmove = Input.GetAxis("Vertical");
			if (vmove != 0f) {
				climb = true;
				anim.SetBool("climb", true);
			}
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Ladder")) {
			float vmove = Input.GetAxis("Vertical");
			if (vmove != 0f) {
				climb = true;
				anim.SetBool("climb", true);
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Ladder")) {
			rb.gravityScale = gravity;
			rb.drag = linearDrag;
			anim.SetBool("climb", false);
			climb = false;
		}
	}

	void jump() {
		anim.SetBool ("isGrounded", false);
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jumpForce));
	}
	void run() {
		MaxSpeed = MaxSpeed * run_multiplikator;
		anim.SetBool ("run", true);
		//if (run_timer == 0)
		//	notRun ();
	}
	void notRun() {
		MaxSpeed = MaxSpeed / run_multiplikator;
		anim.SetBool ("run", false);
	}
	void m_crouch() {
		anim.SetBool ("crouch", true);
		crouch = true;
	}
	void notCrouch() {
		anim.SetBool ("crouch", false);
		crouch = false;
	}
	void shoot() {
		float move = Input.GetAxis ("Horizontal");
		if (move == 0 || !grounded) {
			nextFire = Time.time + fireRate;
			anim.SetBool ("shoot", true);
			if (!crouch)
				Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
			else if (crouch) {
				Transform crouchShootSpawn = Instantiate (ShotSpawn, ShotSpawn.position, ShotSpawn.rotation) as Transform;
				crouchShootSpawn.position = new Vector3 (ShotSpawn.position.x, ShotSpawn.position.y - 0.4f, ShotSpawn.position.z);
				Instantiate (shot, crouchShootSpawn.position, ShotSpawn.rotation);
			}
			Invoke ("setShootFalse", 0.4f);
		}
	}
	void climbing() {
		float move = Input.GetAxis ("Vertical");
		rb.gravityScale = 0f;
		rb.drag = 5f;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, move * climbSpeed);

	}
	void slash() {
		nextSlash = Time.time + slashRate;
		anim.SetBool ("slash", true);
		if(crouch)
			Invoke ("setSlashFalse", 0.3f);
		else 
			Invoke ("setSlashFalse", 0.6f);
	}

	public void dead() {
		alive = false;
		anim.SetBool ("dead", true);
		if (i == 0) {
			Invoke ("reset", 3f);
			i++;
		}
	}

	void reset() {
		i = 0;
		HP = startHP;
		this.GetComponent<Transform> ().position = resetPos;
		anim.SetBool ("dead", false);
		alive = true;
	}

	void setSlashFalse() {
		anim.SetBool ("slash", false);
	}

	public bool isFacingRight() {
		return FacingRight;
	}

	void setShootFalse() {
		anim.SetBool ("shoot", false);
	}

	public void setHP(float x) {
		this.HP = x;
	}
	public float getHP() {
		return HP;
	}

	public float getNrg () {
		return run_timer;
	}

	public bool isAlive() {
		return alive;
	}
}
