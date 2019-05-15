using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStats : MonoBehaviour
{
    public float DecayTimer;

	void Update()
	{
		DecayTimer -= Time.deltaTime;
		if(DecayTimer < 0)
			this.gameObject.SetActive(false);
	}
}
