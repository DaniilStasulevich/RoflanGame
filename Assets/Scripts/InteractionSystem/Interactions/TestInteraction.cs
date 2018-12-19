using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour, IInteraction {

    public void Action()
    {
        Debug.Log("Ты сказал: \"Иди нахуй\"");
    }
}
