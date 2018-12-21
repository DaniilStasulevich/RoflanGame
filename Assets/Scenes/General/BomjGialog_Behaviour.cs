using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomjGialog_Behaviour : MonoBehaviour {
    public BomjDialog bomjDialog;

    private void Start()
    {
        if (GameStats.ItemCondition.KickBomj)
            gameObject.SetActive(false);

        bomjDialog.node[0].reply[0].OnReplyEvent.AddListener(delegate { GameStats.ItemCondition.KickBomj = true; });
        bomjDialog.node[1].reply[0].OnReplyEvent.AddListener(delegate { GameStats.ItemCondition.KickBomj = true; });

        bomjDialog.node[1].reply[1].OnReplyEvent.AddListener(delegate {
            Inventory.DeleteSomeValueOfStackableItem("Деньги", 5);
            GetComponent<ItemInfo>().ThisItem[0].count += 5;
            if (!Inventory.FindStackItemWithCount_AtLeast("Деньги", 5))
                bomjDialog.node[1].reply[1].ToNode = 9;
        });
        bomjDialog.node[0].reply[1].OnReplyEvent.AddListener(delegate
        {
            Inventory.DeleteSomeValueOfStackableItem("Деньги", 5);
            GetComponent<ItemInfo>().ThisItem[0].count += 5;
            bomjDialog.node[1].reply[1].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 5);
        });
    }
    public void StartThisDialog()
    {
        bomjDialog.startDialog();
    }
}


[System.Serializable]
public class BomjDialog : NPCDialog
{
    public override void startDialog()
    {
        node[0].reply[1].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 5);
        base.startDialog();
    }
}