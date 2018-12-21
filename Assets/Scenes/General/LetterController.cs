using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour {
    private void Start()
    {
        if (GameStats.ItemCondition.SeeLetter)
            gameObject.SetActive(false);
    }
    public void ChangeSeeLetter()
    {
        GameStats.ItemCondition.SeeLetter = true;
    }
}
