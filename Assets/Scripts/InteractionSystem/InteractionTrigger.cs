using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {
    private InteractionManager Manager;

	void Start () {
        Manager = GetComponent<InteractionManager>();
	}

    //Логика того, когда у нас появляется возможность взаиможействовать с NPC (Для примера нам надо просто войти в коллайдер)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnInteractionStart(collision.gameObject);
        Debug.Log("TriggerEnter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnInteractionClosed();
    }


    //То, что произойдет когда у нас появится возможность взаимодействовать с NPC
    public void OnInteractionStart(GameObject o)
    {
        Manager.StartInteraction(o);
    }
    //То, что произойдет когда у нас эта возможность пропадет (отойдем от NPC)
    public void OnInteractionClosed()
    {
        Manager.CloseInteraction();
    }
}
