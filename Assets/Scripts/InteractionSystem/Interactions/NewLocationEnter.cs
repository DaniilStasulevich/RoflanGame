using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLocationEnter : MonoBehaviour, IInteraction {
    public string name { get { return name; } set { } }
    public string Name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Action()
    {
        Debug.Log("перешол, хуле");
    }
}
