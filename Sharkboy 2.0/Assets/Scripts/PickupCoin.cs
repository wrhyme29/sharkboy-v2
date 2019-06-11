using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
	GameStats gs;

	void Start(){
		gs = GameStats.Instance;
	}
    void OnTriggerEnter2D(Collider2D col)
    {
		gs.coins++;
		Destroy(this.gameObject);
    }
}
