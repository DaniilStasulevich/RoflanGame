using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {
	[SerializeField]
	private float speed = 10.0F;

	new private Rigidbody2D rigidbody;
	private Animator animator;
	private SpriteRenderer sprite;

	private void Awake(){

		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer> ();
	}

	private void FixedUpdate(){
		if (Input.GetButton ("Horizontal"))
			RunOnX ();
		if (Input.GetButton ("Vertical"))
			RunOnY ();
		}


	private void RunOnX(){
		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
		sprite.flipX = direction.x > 0.0F;		
	}
	
	private void RunOnY(){
        Vector3 direction = transform.up * Input.GetAxis("Vertical");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
	
	}

  
}


