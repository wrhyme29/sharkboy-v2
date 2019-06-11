using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupCoin : MonoBehaviour
{
	GameStats gs;
	public Text​Mesh​Pro​UGUI text;
	bool locked = false;

	void Start(){
		gs = GameStats.Instance;
		text =  GameObject.Find("CoinsText").GetComponent<TextMeshProUGUI>();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
		if(!locked){
			locked = true;
			gs.coins++;
			UpdateUI();
			Destroy(this.gameObject);
		}

    }

	void UpdateUI(){
		text.text = "Coins: " + gs.coins;
	}
}
