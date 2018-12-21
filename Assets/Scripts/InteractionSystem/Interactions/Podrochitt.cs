using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podrochitt : MonoBehaviour, IInteraction {
    private LongAction longAction;
    public string name { get { return Name; } set { } }
    public string Name;
	// Use this for initialization
	void Start () {
        longAction = GameObject.Find("Player").GetComponent<LongAction>();
	}
	
    public void Action()
    {
        longAction.StartContinuingAction("Drochitt", 3f, delegate { Debug.Log("Podrochil"); });
    }
}
