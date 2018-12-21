using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkins : MonoBehaviour {
	[Header("Спрайты")]
	public Sprite[] sprite;
	public Transform ChangeAbleSkin;
	private int CurrentSprite = 1;
	private Image img;
	public Button Left, Right;
	
	void Start()
	{
		if (CurrentSprite == 0)
			Left.gameObject.SetActive(false);
		if (CurrentSprite == sprite.Length)
			Right.gameObject.SetActive(false);
	}

	public void NextSkin()
	{
		
			Left.gameObject.SetActive(true);
		
			img = ChangeAbleSkin.GetComponent<Image>();

		if (CurrentSprite + 2 == sprite.Length)
		{
			
			Right.gameObject.SetActive(false);
			CurrentSprite++;
			img.sprite = sprite[CurrentSprite];
		}
		else
		{
			CurrentSprite++;
			img.sprite = sprite[CurrentSprite];
			

		}
	}
	public void LastSkin()
	{
		img = ChangeAbleSkin.GetComponent<Image>();
		Right.gameObject.SetActive(true);

		if (CurrentSprite - 1 == 0) 
		{
			Left.gameObject.SetActive(false);
			CurrentSprite--;
			img.sprite = sprite[CurrentSprite];
		}
		else
		{

			CurrentSprite--;
			img.sprite = sprite[CurrentSprite];
		}
	}
}
