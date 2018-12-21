using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    IInteraction[] Interactions = new IInteraction[3];
    private GameObject InteractableObj;
    public bool DrawingInteractions = false;
    public int textSize = 14;
    public Color textColor = Color.white;

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
        InteractableObj = o;
        DrawingInteractions = true;
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
        DrawingInteractions = false;
        Interactions = new IInteraction[3];
    }

    private void OnGUI()
    {
        if (DrawingInteractions)
        {
            drawInteractions();
        }
    }
    private void drawInteractions()
    {
        int j = 1;
        string text = "";
        Vector3 worldPosition = new Vector3(InteractableObj.transform.position.x, 
                                            InteractableObj.transform.position.y + InteractableObj.gameObject.GetComponent<SpriteRenderer>().size.y / 2, 
                                            InteractableObj.transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        screenPosition.y = Screen.height - screenPosition.y;
        for (int i = Interactions.Length - 1; i >= 0; i--)
        {
            if (Interactions[i] != null)
            {
                switch (i)
                {
                    case 0:
                        text = "E - " + Interactions[i].name;
                        break;
                    case 1:
                        text = "Q - " + Interactions[i].name;
                        break;
                    case 2:
                        text = "R - " + Interactions[i].name;
                        break;
                }
                GUIStyle style = new GUIStyle();
                style.fontSize = textSize;
                style.richText = true;
                style.normal.textColor = textColor;
                style.alignment = TextAnchor.MiddleCenter;

                GUI.Label(new Rect(screenPosition.x, screenPosition.y - textSize * 1.5f * j, 0, 0), text, style);
                j++;
            }
        }
    }
}
