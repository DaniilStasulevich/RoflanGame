using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaController : MonoBehaviour {
	public GameObject AlphaObj;
	public Image AlphaImage;
	public bool AlphaA;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.E))
		{
			if(!AlphaA)
			{
				AlphaImage = AlphaObj.GetComponent<Image>();

				AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a + 0.5f * Time.deltaTime);
				if(AlphaImage.color.a>=1.0f)
				{
					AlphaA = true;
				}
			}
			if (AlphaA)
			{
				AlphaImage = AlphaObj.GetComponent<Image>();

				AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a - 0.5f * Time.deltaTime);
				if (AlphaImage.color.a <= 0.0f)
				{
					AlphaA = false;
				}
			}
		}
	}
}
