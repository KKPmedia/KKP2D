using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float startHP = 10f;
	public float MaxSpeed = 30f;
	public float run_multiplikator = 1.5f;
	public float run_timer = 10f;
	static bool FacingRight;
	public Transform GroundCheck;
	public LayerMask whatIsGrounded;
	public float jumpForce = 800f;
	public float climbSpeed = 5f;
	public GameObject shot;
	public Transform ShotSpawn;
	public float fireRate = 1.5f;
	public float slashRate = 1f;
	public GameObject pauseMenu;
	public GameObject gameOver;

	public AudioClip jumpsound;
	public AudioClip slashsound;
	public AudioClip shootsound;

	private AudioSource source;

	Animator anim;
	Rigidbody2D rb;
	bool grounded = false;
	float groundRadius = 0.2f;
	private bool inRun = false, climb = false, crouch = false, alive = true, stopRun = false, standOnMovingPlattform = false;
	private float gravity, linearDrag, nextFire = 0.0f, nextSlash = 0.0f, HP, lives = 3;
	private Vector3 resetPos;
	private Vector2 plattformDirection, plattformSpeed;
	private int i = 0;
	private float startSpeed;
	private bool pause = false;


	void Awake() {
		source = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		if (transform.localScale.x < 0)
			Flip();
		FacingRight = true;
		anim = gameObject.GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody2D> ();
		gravity = rb.gravityScale;
		linearDrag = rb.drag;
		resetPos = new Vector3 (this.GetComponent<Transform> ().localPosition.x, this.GetComponent<Transform> ().localPosition.y);
		HP = startHP;
		startSpeed = MaxSpeed;

		pauseMenu.SetActive (false);
		gameOver.SetActive (false);

	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, whatIsGrounded);
		anim.SetBool ("isGrounded", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);
		
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));
	
		if (climb) 
			climbing ();
		else if (alive && !crouch) {
			if (standOnMovingPlattform && grounded) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 ((move * MaxSpeed) + (plattformSpeed.x * plattformDirection.x), 
				                                                     GetComponent<Rigidbody2D> ().velocity.y);
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * MaxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			}
		}
		
		if (move > 0 && !FacingRight && alive)
			Flip ();
		else if (move < 0 && FacingRight && alive)
			Flip ();
	}
	
	// Update is called once per frame
	void Update() {
		
		if (HP < 1) {
			dead();
		}

		if (Input.GetButtonDown ("Pause") && alive) {
			if (pause) {
				Time.timeScale = 1;
				pauseMenu.SetActive(false);
				pause = false;
			} else if (!pause && alive) {
				Time.timeScale = 0;
				pauseMenu.SetActive(true);
				pause = true;
			}
		}

		if (alive && !pause) {

			if ((grounded) && Input.GetButtonDown ("Jump") && !crouch) {
				source.PlayOneShot (jumpsound);
				jump ();
			}

			if (inRun) {
				if (!grounded || anim.GetFloat ("Speed") == 0)
					source.mute = true;
				else
					source.mute = false;

				run_timer -= Time.deltaTime;
				if (run_timer < 0) {
					run_timer = 0;
					if (!stopRun) {
						stopRun = true;
						notRun ();
					}
				}
			}
			if (!inRun) {
				run_timer += Time.deltaTime;
				if (run_timer > 10) {
					run_timer = 10;
				}
			}
			if (Input.GetButtonDown ("Run") && run_timer > 1) {
				stopRun = false;
				inRun = true;
				run ();
			}
			if (Input.GetButtonUp ("Run")) {
				inRun = false;
				if (!stopRun)
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
	}
	
	void Flip() {
		FacingRight = !FacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;

		Vector3 position = transform.localPosition;
		if (FacingRight)
			position.x += 0.5f;
		if (!FacingRight)
			position.x -= 0.5f;

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

		if (col.CompareTag ("checkpoint")) {
			resetPos = col.transform.position;
			Destroy(col.gameObject);
		}

		if (col.CompareTag ("spikes")) {
			if (alive) {
				dead ();
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

		if (col.CompareTag ("platform")) {
			standOnMovingPlattform = true;
			plattformDirection = col.GetComponent<Plattform_Side_Move>().getDirection();
			plattformSpeed = col.GetComponent<Plattform_Side_Move>().getSpeed();
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Ladder")) {
			rb.gravityScale = gravity;
			rb.drag = linearDrag;
			anim.SetBool ("climb", false);
			climb = false;
		}

		if (col.CompareTag ("platform")) {
			standOnMovingPlattform = false;
		}
	}

	void jump() {
		anim.SetBool ("isGrounded", false);
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jumpForce));
	}
	void run() {
		source.loop = true;
		source.Play();
		MaxSpeed = MaxSpeed * run_multiplikator;
		anim.SetBool ("run", true);
	}
	void notRun() {
		source.loop = false;
		source.mute = false;
		source.Pause ();
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
			if (!crouch) {
				source.PlayOneShot (shootsound);
				Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
			}
			else if (crouch) {
				source.PlayOneShot (shootsound);
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

		source.PlayOneShot (slashsound);

		anim.SetBool ("slash", true);
		if(crouch)
			Invoke ("setSlashFalse", 0.3f);
		else 
			Invoke ("setSlashFalse", 0.6f);
	}

	public void dead() {
		alive = false;
		lives--;
		anim.SetBool ("dead", true);
		if (i == 0) {
			Invoke ("reset", 3f);
			i++;
		}
	}

	void reset() {
		if (lives < 0) {
			gameOver.SetActive (true);
			Time.timeScale = 0;
		} else {
			i = 0;
			run_timer = 10f;
			HP = startHP;
			MaxSpeed = startSpeed;
			this.GetComponent<Transform> ().position = resetPos;
			anim.SetBool ("dead", false);
			alive = true;
		}
	}

	void setPauseTrue () {
		pause = true;
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

	public float getLives() {
		return lives;
	}

	public void setHP(float x) {
		this.HP = x;
	}
	public float getHP() {
		return HP;
	}

	public void setDead() {
		this.HP = 0;
	}

	public float getNrg () {
		return run_timer;
	}

	public bool isAlive() {
		return alive;
	}
}
