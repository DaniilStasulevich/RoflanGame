using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeInteraction : MonoBehaviour, IInteraction {
    private void Start()
    {
        Debug.Log("zalupa");
    }
    public void Action()
    {
        Debug.Log("Началась торговля");
    }
}
