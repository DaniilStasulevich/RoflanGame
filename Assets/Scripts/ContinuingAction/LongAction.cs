using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LongAction : MonoBehaviour {
    public delegate void VoidAction();

    public int textSize = 14;
    public Color textColor = Color.white;

    public float width = 2.5f, height = 0.5f;
    public Texture2D Borders, Fill;
    private float a = 0f;

    public bool ActionInProgress = false;
    public float progress, goal;
    public string actionName;

    public void StartContinuingAction(string name, float time, VoidAction action)
    {
        progress = 0f;
        goal = time;
        actionName = name;
        StartCoroutine(StartContinuingAction_IE(action));
    }

    public IEnumerator StartContinuingAction_IE(VoidAction action)
    {
        while (progress < goal)
        {
            Debug.Log("Increase Progress");
            ActionInProgress = true;
            yield return new WaitForSeconds(0.03f);
            progress += 0.03f;
        }
        ActionInProgress = false;
        action();
        Debug.Log("coroutine ends");
    }

    public void DrawProgressBar()
    {
        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + gameObject.GetComponent<SpriteRenderer>().size.y / 2, transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        screenPosition.y = Screen.height - screenPosition.y - height * 1.5f;
        //screenPosition.x = screenPosition.x - width / 2;

        GUI.DrawTexture(new Rect(screenPosition.x - width / 2, screenPosition.y, width * (progress / goal), height), Fill);
        GUI.DrawTexture(new Rect(screenPosition.x - width / 2, screenPosition.y, width, height), Borders);

        GUIStyle style = new GUIStyle();
        style.fontSize = textSize;
        style.richText = true;
        style.normal.textColor = textColor;
        style.alignment = TextAnchor.MiddleCenter;

        GUI.Label(new Rect(screenPosition.x, screenPosition.y - textSize * 1.5f, 0, 0), actionName, style);
    }

    private void OnGUI()
    {
        if (ActionInProgress)
            DrawProgressBar();
    }

    private void Start()
    {
        //SomeClass.instance.Call();
    }
}

//public class SomeClass : MonoBehaviour
//{
//    public static SomeClass instance;
//    private void Start()
//    {
//        Debug.Log("SomeClass Start");
//        instance = this;
//    }

//    public void Call()
//    {
//        Debug.Log("SomeClass Call");
//    }
//}