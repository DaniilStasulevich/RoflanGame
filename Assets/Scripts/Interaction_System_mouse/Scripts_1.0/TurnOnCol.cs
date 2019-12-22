using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnCol : MonoBehaviour {
	public GameObject gameobject;

	void OnTriggerEnter2D(Collider2D second)
	{
		if (second.tag == "Player")
		{
			//gameobject.GetComponent<BoxCollider2D>().enabled = true;
			gameobject.GetComponent<Button>().enabled = true;

		}


	}
	void OnTriggerExit2D(Collider2D second)
	{
		if (second.tag == "Player")
		{
			//gameobject.GetComponent<BoxCollider2D>().enabled = false;
			gameobject.GetComponent<Button>().enabled = false;
		}


	}
}
