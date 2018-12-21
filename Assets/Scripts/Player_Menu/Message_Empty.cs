using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Empty : MonoBehaviour {

    public Message ThisMessage;

    public void AddThisMessage()
    {
        ThisMessage.AddThisMessageToInventory();
    }
}
