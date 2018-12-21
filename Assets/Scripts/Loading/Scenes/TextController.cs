using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	// Use this for initialization
	void Awake () {
        gameObject.GetComponent<Text>().text = SceneINFO_Dialog.PreSceneText;
	}
}
