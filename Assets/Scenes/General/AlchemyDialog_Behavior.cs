using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyDialog_Behavior : MonoBehaviour {
    public AlchemyDialog Alchemy_Dialog;
    public SelfDialog_ Dialog;
    public GameObject Letter1, Letter2, girl;
    public void PutIngridient(string name, int slot)
    {
        int i = 0;
        Inventory.FindItemWithName(name, ref i);
        if (ItemInAlchemyCase.Items[slot] != null)
        {
            ItemInAlchemyCase.Items[slot].AddItem();
        }
        ItemInAlchemyCase.Items[slot] = Inventory._inventory[i].ConstractItem();
        Inventory.DeleteItemWithName(name);
        //Alchemy_Dialog.FillItemsInNode();
    }
    private void Start()
    {
        Alchemy_Dialog.Node1Original = Alchemy_Dialog.node[1].NPC_Text;

        Alchemy_Dialog.node[3].reply[0].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Кристалл", 0);
        });
        Alchemy_Dialog.node[3].reply[1].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Корень", 0);
        });
        Alchemy_Dialog.node[3].reply[2].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Язык Икабоса", 0);
        });
        Alchemy_Dialog.node[3].reply[3].OnReplyEvent.AddListener(delegate
        {
            if (ItemInAlchemyCase.Items[0] != null)
            {
                ItemInAlchemyCase.Items[0].AddItem();
                ItemInAlchemyCase.Items[0] = null;
            }
            Alchemy_Dialog.FillItemsInNode();
        });

        Alchemy_Dialog.node[4].reply[0].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Кристалл", 1);
        });
        Alchemy_Dialog.node[4].reply[1].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Корень", 1);
        });
        Alchemy_Dialog.node[4].reply[2].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Язык Икабоса", 1);
        });
        Alchemy_Dialog.node[4].reply[3].OnReplyEvent.AddListener(delegate
        {
            if (ItemInAlchemyCase.Items[1] != null)
            {
                ItemInAlchemyCase.Items[1].AddItem();
                ItemInAlchemyCase.Items[1] = null;
                Alchemy_Dialog.FillItemsInNode();
            }

        });

        Alchemy_Dialog.node[5].reply[0].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Кристалл", 2);
        });
        Alchemy_Dialog.node[5].reply[1].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Корень", 2);
        });
        Alchemy_Dialog.node[5].reply[2].OnReplyEvent.AddListener(delegate
        {
            PutIngridient("Язык Икабоса", 2);
        });
        Alchemy_Dialog.node[5].reply[3].OnReplyEvent.AddListener(delegate
        {
            if (ItemInAlchemyCase.Items[2] != null)
            {
                ItemInAlchemyCase.Items[2].AddItem();
                ItemInAlchemyCase.Items[2] = null;
                Alchemy_Dialog.FillItemsInNode();
            }

        });

        Alchemy_Dialog.node[1].reply[4].OnReplyEvent.AddListener(delegate
        {
            if (GameStats.Dialogs.TellMerchantAboutWomen)
            {
                if ((ItemInAlchemyCase.Items[0].name == "Корень") && (ItemInAlchemyCase.Items[1].name == "Язык Икабоса") && (ItemInAlchemyCase.Items[2].name == "Кристалл"))
                    Alchemy_Dialog.node[1].reply[4].ToNode = 9;
            }
            else
            {
                Inventory.DialogPanel.gameObject.SetActive(false);
                Inventory.Door.GetComponent<BoxCollider2D>().enabled = false;
                IEnumerator HuitaBlyat = AlphaChecker();
                Inventory.AlphaObject.GetComponent<Alpha>().fadeState = Alpha.FadeState.In;
                StartCoroutine(HuitaBlyat);
            }
        });
    }
    public void StartDialog()
    {
        Alchemy_Dialog.startDialog();
    }
    IEnumerator AlphaChecker()
    {
        Debug.Log("Start Coroutine");
        while (Inventory.AlphaObject.GetComponent<Alpha>().fadeState != Alpha.FadeState.InEnd)
        {
            Debug.Log("Working");
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("InEnd");
        if ((ItemInAlchemyCase.Items[0].name == "Корень") && (ItemInAlchemyCase.Items[1].name == "Язык Икабоса") && (ItemInAlchemyCase.Items[2].name == "Кристалл"))
            Letter1.SetActive(true);
        else
            Letter2.SetActive(true);
        Inventory.AlphaObject.GetComponent<Alpha>().fadeState = Alpha.FadeState.Out;
        girl.SetActive(false);
        Dialog.startDialog();
        //StopAllCoroutines();
        yield return null;

    }
}

[System.Serializable]
public class AlchemyDialog : NPCDialog
{
    [HideInInspector]
    public string Node1Original;
    public void FillItemsInNode()
    {
        node[1].NPC_Text = Node1Original;
        for (int i = 0; i < 3; i++)
        {
            int StartIndex = 0;
            for (int j = 0; j < i + 1; j++)
            {
                StartIndex = node[1].NPC_Text.IndexOf("[", StartIndex + 1);
            }
            if (ItemInAlchemyCase.Items[i] == null)
            {
                node[1].NPC_Text = node[1].NPC_Text.Insert(StartIndex + 1, "Ничего").ToString();
                Debug.Log("Insert Nothing");
            }
            else
            {
                node[1].NPC_Text = node[1].NPC_Text.Insert(StartIndex + 1, ItemInAlchemyCase.Items[i].name);
                Debug.Log("Insert Item");
            }
        }
    }
    public override void putNode()
    {
        FillItemsInNode();
        node[3].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        node[3].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        node[3].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[4].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        node[4].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        node[4].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[5].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        node[5].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        node[5].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        bool AllItems = true;
        for (int i = 0; i < 3; i++)
            if (ItemInAlchemyCase.Items[i] == null)
            {
                AllItems = false;
                break;
            }
        node[1].reply[4].ShoudBeShowen = AllItems;
        base.putNode();
    }
}