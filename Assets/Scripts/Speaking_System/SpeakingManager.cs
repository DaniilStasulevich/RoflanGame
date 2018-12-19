using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingManager : MonoBehaviour {

    public List<SpeakerClass> Speakers;


    public SpeakerClass FindSpeaker(string name)
    {
        foreach(var o in Speakers)
        {
            if (o.name == name.ToString())
                return o;
        }
        return null;
    }
}



public class SpeakerPair
{

}