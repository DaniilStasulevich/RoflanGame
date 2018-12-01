using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNewScene : MonoBehaviour {
    [TextArea]
    public string PreSceneText;
    public int index;
    private void Start()
    {
        foreach (var Item in Inventory._inventory)
        {
            if (Item != null)
            {
                int FreeSlotIndex = 0;
                for (int i = 0; i <= 14; i++)
                {
                    // Если i-ый элемент не существует то...
                    try
                    {
                        Inventory.InventoryPanel.GetChild(i).GetChild(0);
                        Debug.Log("Try");

                    }
                    catch
                    {
                        Debug.Log("Catch");
                        FreeSlotIndex = i;
                        break;
                    }
                }
                if (Item.IsStackable == true)
                {
                    // Добавляем предмет в пустой слот.
                    Transform panel = Instantiate(Item.PrefabItem, Inventory.InventoryPanel.GetChild(FreeSlotIndex));
                    // Записываем этот предмет в массив класса.
                    panel.GetChild(0).GetComponent<Text>().text = Item.count.ToString();
                    // Ломаем нахуй код.
                }
                else
                {
                    Instantiate(Item.PrefabItem, Inventory.InventoryPanel.GetChild(FreeSlotIndex));
                }
            }
        }
    }
    public void LoadScene()
    {
        SceneINFO_Dialog.PreSceneText = PreSceneText;
        SceneINFO_Dialog.ScenIDLoad = index;
        SceneManager.LoadScene(1);
    }


}
