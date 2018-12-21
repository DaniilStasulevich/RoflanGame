using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour, IInteraction
{
    LongAction longAction;
    private void Start()
    {
        longAction = gameObject.GetComponent<LongAction>();
    }

    public void Action()
    {
        Debug.Log("Press E");
        longAction.StartContinuingAction("Drochu", 5, delegate { Debug.Log("Podrochil"); });
    }
}
