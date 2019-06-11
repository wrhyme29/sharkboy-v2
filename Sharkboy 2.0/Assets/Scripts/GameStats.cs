using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{

	#region Singleton
	public static GameStats Instance;   

	//Awake is always called before any Start functions
	void Awake()
	{
		Instance = this;
	}

	#endregion
	
   public int coins = 0;
}
