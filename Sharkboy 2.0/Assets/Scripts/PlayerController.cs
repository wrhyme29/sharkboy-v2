using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float horizontalInput;
	private int velocitySign;
	private Rigidbody2D rb;
	private int orientation;

	public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalInput = Input.GetAxis("Horizontal");
		rb = GetComponent<Rigidbody2D>();
		velocitySign = 0;
		orientation = 1;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
		velocitySign = Sign((int)horizontalInput);
    }

	void FixedUpdate(){
		UpdateVelocity();
		if(velocitySign != orientation && velocitySign != 0) Flip();
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
