using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamodInteraction : MonoBehaviour, IInteraction {
    private LongAction longAction;
    public string name { get { return Name; } set { } }
    public string Name;
    void Start()
    {
        longAction = GameObject.Find("Player").GetComponent<LongAction>();
    }
    
    public void Action()
    {
        longAction.StartContinuingAction("Роется в шкафу", 3f, delegate { Debug.Log("Нашел какую-то хуйню"); });
    }
}
