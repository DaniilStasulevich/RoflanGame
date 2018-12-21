using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour {
    public GameObject Menu;
    private bool MenuActivity = false;

    //Открывает меню игрока при нажатии на E
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MenuActivity = !MenuActivity;
            Menu.SetActive(MenuActivity);
        }
	}
}
