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
		if(Input.GetMouseButtonDown(1)){
			mousePosition = Input.mousePosition;
			destroyPlatform(mousePosition);
		}
	}

	GameObject createPlatform(Vector3 mousePosition)
	{
		//this somewhat works, research changing this to an overlap circle to cover a threshold
		Vector2 mousePos = cam.ScreenToWorldPoint(mousePosition); 
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
		//if anything is collided
		if (hit.collider != null)
		{
			Debug.Log(hit.collider.name);
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
