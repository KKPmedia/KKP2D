using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CoinScript : MonoBehaviour {

	public GameObject hud_ui;
	public float coinPoints = 15f;
	public AudioClip coinsound;

	private AudioSource source;
	private HUD_UI hud_ui_script;
	static float coins;


	void Awake() {
		//source = gameObject.GetComponent<AudioSource>();
	}
	void Start() {
		hud_ui_script = hud_ui.GetComponent<HUD_UI> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint(coinsound, transform.position);
			hud_ui_script.setEarnedMoney (hud_ui_script.getEarnedMoney() + coinPoints);
			Destroy (this.gameObject, 0f);
		}
	}

	void Update() {
		coins = hud_ui_script.getEarnedMoney ();
	}

	public static float getCoins() {
		return coins;
	}
}
