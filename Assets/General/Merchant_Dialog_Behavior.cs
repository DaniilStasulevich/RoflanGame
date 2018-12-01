using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Dialog_Behavior : MonoBehaviour {
    public Merchant_Dialog Merchant_Dialog;

    public void StartDialog()
    {
        Merchant_Dialog.startDialog();
    }
    private void Start()
    {
        Merchant_Dialog.node[1].reply[1].OnReplyEvent.AddListener(delegate { GameStats.ItemCondition.SpeackAboutKing = true; });
        Merchant_Dialog.node[0].reply[1].OnReplyEvent.AddListener(delegate { GameStats.ItemCondition.SpeackAboutKing = true; });

        Merchant_Dialog.node[4].reply[0].OnReplyEvent.AddListener(delegate { GameStats.Dialogs.TellMerchantAboutWomen = true; });
        Merchant_Dialog.node[5].reply[0].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 100); });
        //node[5].reply[0].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 100); });
        Merchant_Dialog.node[5].reply[0].OnReplyEvent.AddListener(delegate {
            Merchant_Dialog.node[7].reply[2].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 25);
            Merchant_Dialog.node[8].reply[1].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 25);

        });
        Merchant_Dialog.node[6].reply[1].OnReplyEvent.AddListener(delegate { GameStats.Dialogs.KnowAboutFlower = true; });

        Merchant_Dialog.node[7].reply[2].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 25); });
        Merchant_Dialog.node[8].reply[1].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 25); });
        Merchant_Dialog.node[9].reply[1].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 25); });
    }

}
[System.Serializable]
public class Merchant_Dialog : NPCDialog
{
    public override void startDialog()
    {
        node[1].reply[1].ShoudBeShowen = !GameStats.ItemCondition.SpeackAboutKing;
        node[1].reply[3].ShoudBeShowen = GameStats.Dialogs.KnowAboutFlower;
        node[0].reply[2].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 100);
        node[1].reply[2].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 100);
        //node[1].reply[1].OnReplyEvent.AddListener(delegate { node[1].reply[1].ShoudBeShowen = false; });
        node[3].reply[1].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 100);
        node[3].reply[2].ShoudBeShowen = GameStats.Dialogs.KnowAboutFlower;
        //node[4].reply[0].OnReplyEvent.AddListener(delegate { GameStats.Dialogs.TellMerchantAboutWomen = true; });
        //node[5].reply[0].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 100); });
        ////node[5].reply[0].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 100); });
        //node[5].reply[0].OnReplyEvent.AddListener(delegate {
        //    node[7].reply[2].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 25);
        //    node[8].reply[1].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 25);

        //});
        //node[6].reply[1].OnReplyEvent.AddListener(delegate { GameStats.Dialogs.KnowAboutFlower = true; });
        node[9].reply[1].ShoudBeShowen = Inventory.FindStackItemWithCount_AtLeast("Деньги", 25);
        base.startDialog();
    }
}