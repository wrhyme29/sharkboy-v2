using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetails : MonoBehaviour
{
    public int levelNumber;
	private GameObject player;

	void Awake(){
		player = GameObject.FindWithTag("Player");
		player.GetComponent<PlayerController>().currLevel = levelNumber;
	}
}
