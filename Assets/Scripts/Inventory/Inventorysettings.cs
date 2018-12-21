using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorysettings : MonoBehaviour {
    public Transform _InventoryPanel;
    public Transform NoficationsContent;
    public Transform NotificationItemPenel_Prefab;
    public Transform DialogPanel;
    // Use this for initialization
    private void Awake () {
        Inventory.InventoryPanel = _InventoryPanel;
        Inventory.NoficationsContent = NoficationsContent;
        Inventory.NotificationItemPenel_Prefab = NotificationItemPenel_Prefab;
        Inventory.DialogPanel = DialogPanel;
	}
	
}
