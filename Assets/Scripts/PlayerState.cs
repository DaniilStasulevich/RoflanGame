using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public static PlayerState instance;

    public Vector2 viewDirection;

    public void LookAt(look lookAt)
    {
        switch (lookAt)
        {
            case look.up:
                viewDirection = Vector2.up;
                break;
            case look.down:
                viewDirection = -Vector2.up;
                break;
            case look.right:
                viewDirection = Vector2.right;
                break;
            case look.left:
                viewDirection = -Vector2.right;
                break;
            default:
                Debug.Log("Wrong State");
                break;
        }
    }
    private void Start()
    {
        instance = this;
    }
    public enum look
    {
        up,
        down,
        left,
        right
    }
}
