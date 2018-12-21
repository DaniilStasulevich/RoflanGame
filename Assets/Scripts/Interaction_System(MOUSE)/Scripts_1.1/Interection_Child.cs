using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interection_Child : MonoBehaviour {
    [HideInInspector]
    public Texture2D cursorTexture;
    [HideInInspector]
    public CursorMode cursorMode = CursorMode.Auto;
    [HideInInspector]
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    { //Просто заносим в переменную спрайта курсора ту же текстуру, что и в скрипте основного объекта
        cursorTexture = gameObject.GetComponentInParent<Interection_Main>().cursorTexture;
        hotSpot = gameObject.GetComponentInParent<Interection_Main>().hotSpot;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.tag == "Player") //Если в область заходит игрок
        {
            if (gameObject.GetComponentInParent<Interection_Main>().MouseOnObject) //Если в это время мышь наведена на объект
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode); //Задаем вид курсора
            gameObject.GetComponentInParent<Interection_Main>().InCollider = true; //"Говорим" скрипту основного объекта, что игрок в зоне взаимодействия
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.tag == "Player")
        {
            gameObject.GetComponentInParent<Interection_Main>().InCollider = false;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
}
