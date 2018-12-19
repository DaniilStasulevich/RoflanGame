using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeachTriggerCollider : MonoBehaviour
{
    public delegate void SpeechHandler(SpeakerWithIndex speech);
    public event SpeechHandler speechOutput;
    [HideInInspector]
    public Speech SpeechDelegate;
    public SpeakerWithIndex[] Statements;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Collision Deteched");
            foreach (var o in Statements)
            {
                speechOutput(o);
            }
        }
    }
}

[System.Serializable]
public class SpeakerWithIndex
{
    public SpeakerClass speaker;
    public int ID;
}
