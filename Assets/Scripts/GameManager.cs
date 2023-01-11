using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool canMove;
    public bool canMoveRight;
    public bool canMoveLeft;
    void Awake()
    {
        if(gameManager == null)
            gameManager = this;
        else
            Destroy(gameObject);
        canMoveRight = false;
        canMoveLeft = false;
    }
}
