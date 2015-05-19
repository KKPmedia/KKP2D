using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_UI : MonoBehaviour {

	public GameObject nrg_bar;
	public GameObject player;
	public GameObject hp_bar;
	public GameObject money_text;
	public GameObject playerName;

<<<<<<< HEAD
 	public string earned_Money;
=======
	private string earned_Money;
>>>>>>> origin/master
	private Image hp_fill_img;
	private Image nrg_bar_img;
	private PlayerController pc;

	public static float money;

	public GameObject lp_3;
	private Image lp_3_img;
	public GameObject lp_2;
	private Image lp_2_img;
	public GameObject lp_1;
	private Image lp_1_img;

	private int lifes = 3;
	

	// Use this for initialization
	void Start () {
		hp_fill_img = hp_bar.GetComponent<Image> ();
		pc = player.GetComponent<PlayerController> ();
		nrg_bar_img = nrg_bar.GetComponent<Image> ();

		lp_1_img = lp_1.GetComponent<Image> ();
		lp_2_img = lp_2.GetComponent<Image> ();
		lp_3_img = lp_3.GetComponent<Image> ();

		lp_1_img.enabled = true;
		lp_2_img.enabled = true;
		lp_3_img.enabled = true;

		//earned_Money = money_text.GetComponent<Text> ().text;
		earned_Money = "0";

		playerName.GetComponent<Text> ().text = PlayerPrefs.GetString("Name");
	}
	
	// Update is called once per frame
	void Update () {
		money = float.Parse(earned_Money);

		money_text.GetComponent<Text>().text = earned_Money + "$";

		hp_fill_img.fillAmount = pc.getHP () / 10;
		nrg_bar_img.fillAmount = pc.getNrg () / 10;

		if (pc.getHP() == 0) {
			lifes --;
			if (lifes < 3) {
				lp_3_img.enabled = false;
				pc.setHP(10f);
			}
			if (lifes < 2) {
				lp_2.SetActive(false);
				pc.setHP(10f);
			}
			if (lifes < 1) {
				lp_1.SetActive(false);
				pc.setHP(10f);
			}
		}
	}

	public float getEarnedMoney() {
		return float.Parse(earned_Money);
	}

	public void setEarnedMoney(float x) {
		earned_Money = x.ToString();
	}

	public int getLives() {
		return lifes;
	}
}
