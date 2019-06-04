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
		
		Collider2D playerHit = Physics2D.OverlapCircle(mousePos, platformPlayerCheckRadius);
		//if anything is collided
		if (playerHit != null)
		{
			Debug.Log(playerHit.name);
			if(playerHit.name == "Player")
				return null;
		}

		Collider2D groundHit = Physics2D.OverlapCircle(mousePos, platformGroundCheckRadius);
		//if anything is collided
		if (groundHit != null)
		{
			Debug.Log(groundHit.name);
			if(groundHit.name == "Ground")
				return null;
		}

		Collider2D platformHit = Physics2D.OverlapCircle(mousePos, platformPlatformCheckRadius);
		//if anything is collided
		if (platformHit != null)
		{
			Debug.Log(platformHit.name);
			if(platformHit.name == "Platform(Clone)")
				return null;
		}
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
			hit.transform.gameObject.SetActive(false);
			return hit.transform;
		}
		return null;
	}
}
