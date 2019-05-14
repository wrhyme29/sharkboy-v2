using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size;
		public GameObject parent;
	}

	
	#region Singleton
		public static ObjectPooler Instance;   

		//Awake is always called before any Start functions
		void Awake()
		{
			Instance = this;
		}

	#endregion

	public List<Pool> pools; 
	public Dictionary<string,Queue<GameObject>> poolDictionary;

	// Start is called before the first frame update
	void Start()
	{
		poolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach(Pool pool in pools){
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for(int i = 0; i < pool.size; i++){
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				obj.transform.parent = pool.parent.transform;
				objectPool.Enqueue(obj);
			}

			poolDictionary.Add(pool.tag, objectPool);
		}
	}
	
	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation){

		if(!poolDictionary.ContainsKey(tag)){
			Debug.LogWarning("Pool with tag " + tag + " does not exist.");
			return null;
		}
		GameObject objToSpawn = poolDictionary[tag].Dequeue();
		poolDictionary[tag].Enqueue(objToSpawn);

		objToSpawn.transform.position = position;
		objToSpawn.transform.rotation = rotation;
		objToSpawn.SetActive(true);

		return objToSpawn;
	}
}
