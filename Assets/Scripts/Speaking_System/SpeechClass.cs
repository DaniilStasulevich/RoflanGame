using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Speech
{
    public string text;
    public float Timer = 3f;
    public SpeakerClass ConnectedWith = null;
    public int ConnectedID;
}