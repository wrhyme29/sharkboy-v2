using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float horizontalInput;
	private int velocitySign;
	private Rigidbody2D rb;
	private int orientation = 1;

	public enum movementStates {RIGHT, LEFT, STOP};

	public movementStates playerState;

	public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalInput = Input.GetAxis("Horizontal");
		rb = GetComponent<Rigidbody2D>();
		velocitySign = 0;
		playerState = movementStates.STOP;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
		velocitySign = Sign((int)horizontalInput);
		UpdatePlayerState(velocitySign);
    }

	void FixedUpdate(){
		UpdateVelocity();
		if(velocitySign != orientation && velocitySign != 0) Flip();
	}

	void UpdatePlayerState(int sign){
		switch(sign){
			case 1:
				playerState = movementStates.RIGHT;
				break;
			case 0:
				playerState = movementStates.STOP;
				break;
			case -1:
				playerState = movementStates.LEFT;
				break;
			default:
				Debug.Log("Something is very wrong with this sign: " + sign);
				break;
		}
	}

	void UpdateVelocity(){
		rb.velocity = new Vector2(speed * velocitySign, 0);
	}


	void Flip(){
		orientation *= -1;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

	private int Sign(int number) {
      return number < 0 ? -1 : (number > 0 ? 1 : 0);
  }
}
