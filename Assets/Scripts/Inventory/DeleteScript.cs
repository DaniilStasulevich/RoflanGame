using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeleteScript : MonoBehaviour
{
    // Кнопка на которой будет функция удаления.
    public Transform button;
    // Какая кнопка по счёту.(не понял как сделать нормально сделал костыль(полукостыль))
    public int count;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { DestroyItem(); });
    }

    // Функция удаления дочернего объекта кнопки.
    public void DestroyItem()
    {
        // Код ниже думаю объяснять не надо.

        Transform slott = button.GetChild(0);
        Inventory._inventory[count] = null;
        Destroy(slott.gameObject);
    }

}
