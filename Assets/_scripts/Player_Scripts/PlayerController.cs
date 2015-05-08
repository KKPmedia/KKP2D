using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float HP = 10;
	public float MaxSpeed = 30f;
	public float run_multiplikator = 1.5f;
	public float run_timer = 10f;
	private bool inRun = false;

	static bool FacingRight = true;
	
	Animator anim;
	Rigidbody2D rb;
	
	bool grounded = false;

	public Transform GroundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGrounded;
	
	public float jumpForce = 700f;

	private bool climb = false;
	private float gravity;
	private float linearDrag;
	public float climbSpeed = 5f;

	private bool crouch = false;

	public GameObject shot;
	public Transform ShotSpawn;
	private float nextFire = 0.0f;
	public float fireRate = 1.5f;

	private float nextSlash = 0.0f;
	public float slashRate = 1f;
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody2D> ();
		gravity = rb.gravityScale;
		linearDrag = rb.drag;
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, whatIsGrounded);
		anim.SetBool ("isGrounded", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));

		if (climb) 
			climbing ();
		else
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * MaxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
		if (move > 0 && !FacingRight)
			Flip ();
		else if (move < 0 && FacingRight)
			Flip();
	}
	
	// Update is called once per frame
	void Update() {
		if (HP == 0) {
			dead();
		}
		if ((grounded) && Input.GetKeyDown(KeyCode.Space)) {
			jump();
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
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			inRun = true;
			run();
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			inRun = false;
			notRun ();
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			m_crouch();
		}
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			notCrouch();
		}
		if (Input.GetMouseButtonDown (0) && Time.time > nextFire) {
			shoot();
		}
		if (Input.GetKeyDown (KeyCode.E) && Time.time > nextSlash) {
			slash();
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
		if (run_timer == 0)
			notRun ();
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
		if (!climb && move == 0 || !grounded) {
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
	void dead() {
		anim.SetBool ("dead", true);
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
}
