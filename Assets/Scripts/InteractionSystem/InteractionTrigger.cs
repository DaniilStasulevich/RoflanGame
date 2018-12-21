using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {
    private InteractionManager Manager;
    RaycastHit2D lastHit = new RaycastHit2D();
    LayerMask mask;
    void Start () {
        Manager = GetComponent<InteractionManager>();
        mask = LayerMask.GetMask("CommonRay");
    }
    //Логика того, когда у нас появляется возможность взаиможействовать с NPC
    //Логика с лучами
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerState.instance.viewDirection, 5.0f);
        if (hit.collider != null && hit.collider.tag == "Interactable")
        {
            if (lastHit.collider != null && hit.collider.gameObject == lastHit.collider.gameObject)
            {
                OnInteractionStart(hit.collider.gameObject);
                Debug.Log("LookAt Same " + hit.collider.name);
            }
            else
            {
                lastHit = hit;
                OnInteractionClosed();
                OnInteractionStart(hit.collider.gameObject);
                Debug.Log("LookAt " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("Look At Nothing");
            OnInteractionClosed();
        }
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
