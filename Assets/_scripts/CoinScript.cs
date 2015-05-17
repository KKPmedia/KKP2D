using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	public GameObject hud_ui;
	public float coinPoints = 15f;

	private HUD_UI hud_ui_script;
	static float coins;

	void Start() {
		hud_ui_script = hud_ui.GetComponent<HUD_UI> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
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
