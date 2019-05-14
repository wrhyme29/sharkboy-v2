using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner
{
	ObjectPooler objectPooler;

	private void Start(){
		objectPooler = ObjectPooler.Instance;
	}

    public GameObject spawnPlatform(Vector3 position, Quaternion rotation){
		GameObject platform = objectPooler.SpawnFromPool("Platform", position, rotation);
		return platform;
	}
}
