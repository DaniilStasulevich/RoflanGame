using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sasha_Dialog_Behavior : MonoBehaviour {

    public Sasha_Dialog Sasha_Dialog;
    public GameObject LastMessage;

    private void Start()
    {
        if (GameStats.Dialogs.TellMerchantAboutWomen)
        {
            gameObject.SetActive(false);
            LastMessage.SetActive(true);
        }
        Sasha_Dialog.node[10].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Кристалл") && Inventory.FindItemWithName("Корень") && Inventory.FindItemWithName("Язык Икабоса");
        Sasha_Dialog.node[11].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Кристалл") && Inventory.FindItemWithName("Корень") && Inventory.FindItemWithName("Язык Икабоса");

    }
    public void StartDialog()
    {
        Sasha_Dialog.startDialog();
    }
}


[System.Serializable]
public class Sasha_Dialog : NPCDialog
{
    public override void startDialog()
    {
        if ((GameStats.Dialogs.CurrentNode_NPC[0] == 3) || (GameStats.Dialogs.CurrentNode_NPC[0] == 5))
            if (Inventory.FindItemWithName("Кристалл") && Inventory.FindItemWithName("Корень"))
                GameStats.Dialogs.CurrentNode_NPC[0] = 6;
        if (Inventory.FindItemWithName("Кристалл") && Inventory.FindItemWithName("Корень"))
        {
            node[1].reply[2].ShoudBeShowen = true;
            node[2].reply[1].ShoudBeShowen = true;
        }

        base.startDialog();
    }
}
