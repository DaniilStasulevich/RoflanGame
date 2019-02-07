using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoorInteraction : MonoBehaviour, IInteraction {
    public string name { get { return Name; } set { } }
    public string Name;

    public string OutputText;
    public void Action()
    {
        Debug.Log(OutputText);
    }
}
