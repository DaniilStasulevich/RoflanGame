using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public Item[] ThisItem;

    //Функция добавления этого предмета в инвентарь
    public void AddThisItem(int index)
    {
        ThisItem[index].AddItem();
    }
}