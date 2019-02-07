using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPassing : MonoBehaviour {

    public int toFloor;
    private int ToFloor = 10;
	// Use this for initialization
	void Start () {
        ToFloor += toFloor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.layer = ToFloor;
    }

}
