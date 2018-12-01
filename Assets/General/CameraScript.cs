using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject MainCamera, player;
    public GameObject LeftBorder, RightBorder, TopBorder, BotBorder;
    private Camera _camera;
    private float YMove, XMove, res;
    [SerializeField]
	// Use this for initialization
	void Start () {
        _camera = MainCamera.GetComponent<Camera>();
        res = (float)Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update () {
        if ((player.transform.position.y > (BotBorder.transform.position.y + _camera.orthographicSize)) && (player.transform.position.y < (TopBorder.transform.position.y - _camera.orthographicSize)))
            YMove = player.transform.position.y;
        else YMove = transform.position.y;
        if ((player.transform.position.x > (LeftBorder.transform.position.x + _camera.orthographicSize * res)) && (player.transform.position.x < (RightBorder.transform.position.x - _camera.orthographicSize * res)))
            XMove = player.transform.position.x;
        else XMove = transform.position.x;
        transform.position = new Vector3(XMove, YMove, transform.position.z);

    }
}
