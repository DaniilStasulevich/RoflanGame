using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {
    private InteractionManager Manager;
    RaycastHit2D lastHit = new RaycastHit2D();
    LayerMask mask;

    // Количество лучей
    [SerializeField]
    [Range(1, 90)]
    public int numberOfRays = 6;

    // Угол падения лучей
    [SerializeField]
    [Range(-360, 360)]
    public float lightAngle = 0;

    // Расстояние между лучами
    [SerializeField]
    [Range(0, 360)]
    public float lightCone = 90;

    private SpriteRenderer sprite;

    private float originOffset = 0.5f;

    public float raycastMaxDistance = 10f;

    [SerializeField]
    public float lightSourceSize = 0;

    void Start () {
        Manager = GetComponent<InteractionManager>();
        mask = LayerMask.GetMask("CommonRay");
    }
    //Логика того, когда у нас появляется возможность взаиможействовать с NPC
    //Логика с лучами
    private void Update()
    {
        ////Пускаем луч с позиции игрока в том направлении, куда он смотрит, на слое,который игнорит коллайдер игрока. Дистанция 5
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerState.instance.viewDirection, 5.0f);
        //if (hit.collider != null && hit.collider.tag == "Interactable") //Если натыкаемся на объект, с которым можно взаимодействовать
        //{
        //    if (lastHit.collider != null && hit.collider.gameObject == lastHit.collider.gameObject)
        //    {
        //        OnInteractionStart(hit.collider.gameObject);
        //        Debug.Log("LookAt Same " + hit.collider.name);
        //    }
        //    else
        //    {
        //        lastHit = hit;
        //        OnInteractionClosed();
        //        OnInteractionStart(hit.collider.gameObject);
        //        Debug.Log("LookAt " + hit.collider.name);
        //    }
        //}
        //else
        //{
        //    Debug.Log("Look At Nothing");
        //    OnInteractionClosed();
        //}

        CreateVectors();
    }

    private void CreateVectors()
    {
        float RaySpacing = lightCone / numberOfRays;
        float initialAngle = lightAngle - (lightCone / 2);

        Vector3 initialLocation = transform.position + (new Vector3(Mathf.Cos(Mathf.Deg2Rad * (lightAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (lightAngle - 90))) * lightSourceSize / 2);
        Vector3 locationOffset = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (lightAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (lightAngle - 90))) * lightSourceSize / numberOfRays;

        GameObject InteractionObj = null;
        for (int i = 0; i < numberOfRays; i++)
        {
            Vector3 origin = initialLocation - (locationOffset * i);
            Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (i * RaySpacing + initialAngle)) * raycastMaxDistance, Mathf.Sin(Mathf.Deg2Rad * (i * RaySpacing + initialAngle)) * raycastMaxDistance);
            if (hit)
            {
                Debug.DrawRay(origin, (direction * hit.distance / raycastMaxDistance), Color.yellow);
                if (hit.transform.gameObject.GetComponent<IInteraction>() != null)
                    InteractionObj = hit.transform.gameObject;
            }
            else
            {
                Debug.DrawRay(origin, direction, Color.red);
            }
            if (InteractionObj != null)
                OnInteractionStart(InteractionObj);
            else OnInteractionClosed();
        }

    }

    //То, что произойдет когда у нас появится возможность взаимодействовать с NPC
    public void OnInteractionStart(GameObject o)
    {
        Manager.StartInteraction(o);
        Debug.Log("Interaction starts");
    }
    //То, что произойдет когда у нас эта возможность пропадет (отойдем от NPC)
    public void OnInteractionClosed()
    {
        Manager.CloseInteraction();
        Debug.Log("Interaction Closed");
    }
}
