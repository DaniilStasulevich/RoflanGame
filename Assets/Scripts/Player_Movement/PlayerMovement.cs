using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerState.instance.LookAt(PlayerState.look.up);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerState.instance.LookAt(PlayerState.look.down);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerState.instance.LookAt(PlayerState.look.right);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerState.instance.LookAt(PlayerState.look.left);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
    }

}
