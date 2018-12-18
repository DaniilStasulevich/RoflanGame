using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	
	public Transform StartPosition;
	public Transform EndPosition;
	public float speed;
	private float maximum;
	private float minimum;
	
	// starting value for the Lerp
	static float t = 0.0f;

	void Start()
	{
		minimum = StartPosition.position.x;
		maximum = EndPosition.position.x;
		
		
	}
	void Update()
	{
		// animate the position of the game object...
		transform.position = new Vector3(Mathf.Lerp(minimum ,maximum, t), 0, 0);

		// .. and increase the t interpolater
		t += speed * Time.deltaTime;

		// now check if the interpolator has reached 1.0
		// and swap maximum and minimum so game object moves
		// in the opposite direction.
		if (t > 1.0f)
		{
			float temp = maximum;
			maximum = minimum;
			minimum = temp;
			t = 0.0f;
		}
	}

}
