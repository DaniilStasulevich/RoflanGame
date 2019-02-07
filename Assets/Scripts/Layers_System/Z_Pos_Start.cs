using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Pos_Start : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - ((gameObject.layer - 11) * 30));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
