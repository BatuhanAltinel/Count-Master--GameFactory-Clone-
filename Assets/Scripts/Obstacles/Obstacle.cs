using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public virtual void OnMove()
    {

    }
    public void OnDestroyObject(GameObject obj)
    {
        if(obj.GetComponent<Player>())
        {
            obj.GetComponent<Player>().Die();
            GameManager.Instance.UpdatePlayerCountText();
            GameManager.Instance.CheckGameOver();
            GameManager.Instance.MoveAllTeamToMiddle(1.2f);
        }
        
    }
}
