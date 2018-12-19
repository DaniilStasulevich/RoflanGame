using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {
    IInteraction[] Interactions = new IInteraction[3];

    void Update () {
        if (Input.GetKeyDown(KeyCode.E) && Interactions[0] != null)
            Interactions[0].Action();
        if (Input.GetKeyDown(KeyCode.Q) && Interactions[1] != null)
            Interactions[1].Action();
        if (Input.GetKeyDown(KeyCode.R) && Interactions[2] != null)
            Interactions[2].Action();
    }

    public void StartInteraction(GameObject o)
    {
        IInteraction[] interactions = o.GetComponents<IInteraction>();
        int i = 0;
        foreach(MonoBehaviour interaction in interactions)
        {
            if (interaction.enabled == true)
            {
                Interactions[i] = (IInteraction)interaction;
                i++;
            }
        }
    }
    public void CloseInteraction()
    {
        Interactions = new IInteraction[3];
    }

}
