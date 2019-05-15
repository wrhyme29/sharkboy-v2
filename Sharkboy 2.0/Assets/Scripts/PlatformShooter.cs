using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformSpawner))]
public class PlatformShooter : MonoBehaviour
{
    private PlatformSpawner ps;
	Vector3 mousePosition;
	public Camera cam;
	public float TimeToLive = 7f;
	
	// Start is called before the first frame update
    void Start()
    {
      ps = GetComponent<PlatformSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
			mousePosition = Input.mousePosition;
			createPlatform(mousePosition);
		}
	}

	GameObject createPlatform(Vector3 mousePosition)
	{
		GameObject platform = ps.spawnPlatform(cam.ScreenToWorldPoint(mousePosition), Quaternion.identity);
		platform.GetComponent<PlatformStats>().DecayTimer = TimeToLive;

		return platform;
	}
}
