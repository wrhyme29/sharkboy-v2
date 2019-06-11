using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
	private bool locked = false;

	void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.collider.name == "Player"){
			if(!locked){
				locked = true;
				CollisionWithPlayer(collision.gameObject);
				locked = false;
			}
		}
    }

	void CollisionWithPlayer(GameObject player){
		player.GetComponent<PlayerController>().HitByEnemy();
	}
}
