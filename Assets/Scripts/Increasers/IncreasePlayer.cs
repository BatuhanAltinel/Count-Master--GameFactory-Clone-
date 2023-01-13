using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IncreasePlayer : MonoBehaviour
{
    public int increaseAmount;
    public virtual void IncreasePlayerCount()
    {

    }
    public virtual void GameManagerCheck()
    {
        GameManager.Instance.UpdatePlayerCountText();
        GameManager.Instance.MoveAllTeamToMiddle(0);
    }
    public void OnTouchIncreaser()
    {
        Debug.Log(GameManager.Instance.playersInTeam.Count);
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        gameObject.SetActive(false);
        // IncreasePlayerCount();
        
    }

}
