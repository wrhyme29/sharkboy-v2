using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
	public Transform patrolPointLeft;
	public Transform patrolPointRight;

	public float speed = 2f;
	private Rigidbody2D rb;
	private int orientation;
	private bool locked = false;

	 void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		orientation = 1;
    }

    void FixedUpdate()
    {
        UpdateVelocity();
		if(CheckForFlip()) Flip();
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.collider.name == "Platform(Clone)"){
			if(!locked){
				locked = true;
				Flip();
				locked = false;
			}
		}
    }

	void UpdateVelocity(){
		rb.velocity = new Vector2(speed * orientation, rb.velocity.y);
	}


	void Flip(){
		orientation *= -1;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

	bool CheckForFlip(){
		if(orientation == 1){
			if(transform.position.x >= patrolPointRight.position.x) return true;
		} else{
			if(transform.position.x <= patrolPointLeft.position.x) return true;
		}
		return false;
	}
}
