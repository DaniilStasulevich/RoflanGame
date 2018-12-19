using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huita : MonoBehaviour, IInteraction {
    public void Action()
    {
        Debug.Log("Ты сказал: \"Дарова\"");
        gameObject.GetComponent<TradeInteraction>().enabled = false;
    }
}
