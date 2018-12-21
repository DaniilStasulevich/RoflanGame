using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message_Class : MonoBehaviour {
    public MessageSettingsAnother set;

    //Есть экземпляр класса настроек, который прикрепляется к пустому объекту на сцене.
    //В инспекторе мы указываем все необходимые настройки, которые будут применяться ко всем письмам.
    //Потом приравниваем все поля такого же, но статического класса к полям этого экземпляра.
    //Все это делается, чтобы не пришлось для каждого письма ручками в инспекторе указывать одни и те же панель меню, префаб и т.д.

    private void Awake()
    {
        MessageSettingsAnotherStatic.FullTextArea = set.FullTextArea;
        MessageSettingsAnotherStatic._Content = set._Content;
        MessageSettingsAnotherStatic.Prefab = set.Prefab;
    }
    private void Start()
    {
        foreach(var message in MessageInventory.MessageStack)
        {
            GameObject Clone;
            Clone = GameObject.Instantiate(MessageSettingsAnotherStatic.Prefab, MessageSettingsAnotherStatic._Content); //создаем пустую панель письма в меню писем
            Clone.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = message.Miniature; //Задаем миниатюру письма
            Clone.transform.GetChild(1).GetComponent<Text>().text = message.GetMiniText(); //Задаем краткий текст
            Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { message.ShowMessage(message.Text_Message); }); //Задаем инструкции кнопки "Read"
        }
    }
}


/////////////////////Пока еще разбираюсь с этим//////////////////////////////////
//[CreateAssetMenu(fileName = "MessageSettings", menuName = "MessageSettings")]//
//public class MessageSettings : ScriptableObject                              //
//{                                                                            //
//    public GameObject Prefab;                                                //
//    public Transform _Content;                                               //
//    public GameObject FullTextArea;                                          //
//}                                                                            //
/////////////////////////////////////////////////////////////////////////////////


//Класс настроек
[System.Serializable]
public class MessageSettingsAnother
{
    public GameObject Prefab; //Пустая панель письма
    public Transform _Content; //Панел, куда бед добавляться панель письма
    public GameObject FullTextArea; //Панель полного текста письма
}

//Статический класс настроек, который используется для всех писем
public static class MessageSettingsAnotherStatic
{
    public static GameObject Prefab;
    public static Transform _Content;
    public static GameObject FullTextArea;
}

//Коллекция наших писем для будущей базы данных
public static class MessageInventory
{
    public static List<Message> MessageStack = new List<Message>();

    //Проверяет есть ли у нас письмо, которе начинается с *Begining*
    public static bool FindMessage(string Begining)
    {
        bool find = false;
        foreach(var message in MessageStack)
        {
            if (message.Text_Message.Substring(0, Begining.Length) == Begining.ToString())
            {
                find = true;
                break;
            }
        }
        return find;
    }
}


[System.Serializable]
public class Message
{
    public string name;
    [TextArea]
    public string Text_Message; //Текст письма
    public Sprite Miniature; //миниатюра, которая будет отображаться в инвентаре

    //Добавляет письмо в инвентарь
    public void AddThisMessageToInventory()
    {
        MessageInventory.MessageStack.Add(this); //Добавляем новое письмо в коллекцию писем
        GameObject Clone;
        Clone = GameObject.Instantiate(MessageSettingsAnotherStatic.Prefab, MessageSettingsAnotherStatic._Content); //создаем пустую панель письма в меню писем
        Clone.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Miniature; //Задаем миниатюру письма
        Clone.transform.GetChild(1).GetComponent<Text>().text = GetMiniText(); //Задаем краткий текст
        Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { ShowMessage(Text_Message); }); //Задаем инструкции кнопки "Read"
        CreateNotificatioin();
    }

    //Показать полное письмо
    public void ShowMessage(string text)
    {
        MessageSettingsAnotherStatic.FullTextArea.transform.GetChild(0).GetComponent<Text>().text = text;
        MessageSettingsAnotherStatic.FullTextArea.SetActive(true);
    }

    //Функция, которая возвращает сокращенный текст письма
    public string GetMiniText()
    {
        string _Text; //Сокращенный текст письма
        int x = 52; //Колличество букв, которые будут показываться в сокращенном тексте письма

        if (Text_Message.Length < x)
            _Text = Text_Message.ToString();
        else
            _Text = Text_Message.Substring(0, x) + "...";

        return _Text;
    }
    private void CreateNotificatioin()
    {
        var Panel = GameObject.Instantiate(Inventory.NotificationItemPenel_Prefab, Inventory.NoficationsContent); //Создаем пустую панель уведомления о добавленном предмете
        Panel.GetChild(1).GetComponent<Text>().text = name; //"Предмет получен: *добавляем сюда имя этого предмета*"
        GameObject.Destroy(Panel.gameObject, 3); //Уничтожаем эту панель через 3 секунды. Можно было еще через коротину сделать красивое затемнение, но потом уже
    }
}
