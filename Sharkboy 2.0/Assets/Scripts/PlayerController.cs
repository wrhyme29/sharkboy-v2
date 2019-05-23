﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float horizontalInput;
	private int velocitySign;
	private Rigidbody2D rb;
	private int orientation;
	public Animator animator;
	public Collider2D headCollider;

	public float speed = 5f;
	public float jumpForce = 500f;
	float aSpeed;
	float vSpeed;
	bool crouching = false;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		velocitySign = 0;
		orientation = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Left")){
			velocitySign = -1;
		}
		if(Input.GetButtonDown("Right")){
			velocitySign = 1;
		}
		if(Input.GetButtonUp("Left") || Input.GetButtonUp("Right")){
			velocitySign = 0;
		}

		if(Input.GetButtonDown("Jump")){
			Jump();
		}

		if(Input.GetButtonDown("Down")){
			headCollider.enabled = false;
			crouching = true;
			animator.SetBool("Crouching", crouching);
			Debug.Log("crouched");
		}

		if(Input.GetButtonUp("Down")){
			headCollider.enabled = true;
			crouching = false;
			Debug.Log("standing");
			animator.SetBool("Crouching", crouching);
		}

		animator.SetFloat("VerticalVelocity", vSpeed);
    }

	void FixedUpdate(){
		UpdateVelocity();
		if(velocitySign != orientation && velocitySign != 0) Flip();
		vSpeed = rb.velocity.y;
	}

	
	void UpdateVelocity(){
		rb.velocity = new Vector2(speed * velocitySign, rb.velocity.y);
		aSpeed = Mathf.Abs(rb.velocity.x);
		animator.SetFloat("Speed",aSpeed);
	}


	void Flip(){
		orientation *= -1;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

	void Jump(){
		rb.AddForce(new Vector2(0, jumpForce));
		animator.Play("player_jump");
	}

	private int Sign(int number) {
      return number < 0 ? -1 : (number > 0 ? 1 : 0);
  }
}
