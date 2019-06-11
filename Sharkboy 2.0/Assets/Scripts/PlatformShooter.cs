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
	public float platformPlayerCheckRadius = 0.9f;
	public float platformGroundCheckRadius = 0.5f;
	public float platformPlatformCheckRadius = 0.2f;
	
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
		if(Input.GetMouseButtonDown(1)){
			mousePosition = Input.mousePosition;
			destroyPlatform(mousePosition);
		}
	}

	GameObject createPlatform(Vector3 mousePosition)
	{
		Vector2 mousePos = cam.ScreenToWorldPoint(mousePosition); 
		
		if(checkForPlatforms("Player", mousePos, platformPlayerCheckRadius))
			return null;
		if(checkForPlatforms("Ground", mousePos, platformGroundCheckRadius))
			return null;
		if(checkForPlatforms("Platform(Clone)", mousePos, platformPlatformCheckRadius))
			return null;
		
		GameObject platform = ps.spawnPlatform(mousePos, Quaternion.identity);
		platform.GetComponent<PlatformStats>().DecayTimer = TimeToLive;

		return platform;
	}

	Transform destroyPlatform(Vector3 mousePosition){
		Vector2 mousePos = cam.ScreenToWorldPoint(mousePosition); 
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
		//if anything is collided
		if (hit.collider != null)
		{
			if(hit.collider.name == "Platform(Clone)"){
				hit.transform.gameObject.SetActive(false);
				return hit.transform;
			}
		}
		return null;
	}

	bool checkForPlatforms(string name, Vector2 mousePos, float radius){
		Collider2D hit = Physics2D.OverlapCircle(mousePos, radius);
		//if anything is collided
		if (hit != null)
		{
			Debug.Log(hit.name);
			if(hit.name == name)
				return true;
		}

		return false;
	}
}
