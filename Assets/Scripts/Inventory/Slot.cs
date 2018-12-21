using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

	public Sprite activeSlot;
	Sprite slot;
	Image img;
	
	void OnDisable()
	{
		img.sprite = slot;
	}
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		slot = img.sprite;

	}
	
	

	public void OnPointerEnter(PointerEventData eventData)
	{
		img.sprite = activeSlot;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		img.sprite = slot;
	}

}
