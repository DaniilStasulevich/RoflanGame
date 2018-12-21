using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//[System.Serializable]
//public class DialogScript : MonoBehaviour {
//    public NPCDialog DefaultDialog;
//    public Transform _DialogPanel;

   

//    private void Start()
//    {
//    }
//}
[System.Serializable]
public class NPCDialog
{
    public int NPC_ID;
    public string name; 
    public Node[] node;

    [System.Serializable]
    public class Node
    {
        [TextArea]
        public string NPC_Text;
        public Reply[] reply;


        [System.Serializable]
        public class Reply
        {
            //public delegate void ChangeDataBool();
            //public ChangeDataBool _ChangeDataBool;

            public UnityEvent OnReplyEvent;
            public bool CloseDialog;
            public bool ShoudBeShowen = true;
            public string replyText;
            public int ToNode;
        }
    }

    public virtual void startDialog()
    {
        Inventory.DialogPanel.gameObject.SetActive(true);
        Inventory.DialogPanel.GetChild(0).GetComponent<Text>().text = name;
        putNode();
    }

    public void NextNode(Node.Reply reply)   //Запускаем следующий нод
    {
        ChangeNode(reply.ToNode);   //Меняем нод в памяти
        //try
        //{
        //    reply._ChangeDataBool();
        //}
        //catch
        //{
        //}
        if (reply.CloseDialog)  //Закрываем диалог, если надо, или отображаем следующий нод
            Inventory.DialogPanel.gameObject.SetActive(false);
        else putNode();
    }

    public void ChangeNode(int NewNumber)    //Аргумент становится новым нодом, который записывается в память
    {
        GameStats.Dialogs.CurrentNode_NPC[NPC_ID] = NewNumber;
    }

    public virtual void putNode()
    {
        int currentNode = GameStats.Dialogs.CurrentNode_NPC[NPC_ID];  //Записываем номер текущего нода в переменную для удобства
        Inventory.DialogPanel.GetChild(1).GetComponent<Text>().text = node[currentNode].NPC_Text;   //Отображаем текст npc
        Transform Buttons = Inventory.DialogPanel.GetChild(2);    //Заносим панель с кнопками в отдельную переменную для удобства
        int i = 0;  //Индекс текущего ответа
        //Берем по порядку каждую кнопку и, если ответ с таким номером существует и должен быть показан, показываем саму кнопку и добавляем к ней Listener
        foreach (Transform child in Buttons)
        {
            try
            {
                Node.Reply _reply = node[currentNode].reply[i];
                if (!_reply.ShoudBeShowen)  //отключаем объект, если он не должен быть показан
                    child.gameObject.SetActive(false);
                else
                {
                    
                    child.GetComponent<Button>().onClick.RemoveAllListeners();  //Удаляем все прошлые Listeners
                    child.gameObject.SetActive(true);
                    child.GetChild(0).GetComponent<Text>().text = _reply.replyText;    //Текс ответа
                    if (_reply.OnReplyEvent != null)
                        child.GetComponent<Button>().onClick.AddListener(delegate { _reply.OnReplyEvent.Invoke(); }); //Добавляем к кнопке ответа действие, которое мы указали для конкретного ответа
                    child.GetComponent<Button>().onClick.AddListener(delegate { NextNode(_reply); });   //Задаем листенер перехода на следующий нод в зависимости от ответа номера этой кнопки

                }
            }
            catch
            {
                child.gameObject.SetActive(false);  //Отключаем кнопку, если ответа с таким номером не существует
            }
            i++;
        }

    }
}