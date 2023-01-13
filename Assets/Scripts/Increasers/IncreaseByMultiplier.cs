using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseByMultiplier : IncreasePlayer
{
    
    void Start()
    {
        
    }

    public override void IncreasePlayerCount()
    {
         int totalNum =  (increaseAmount-1) * GameManager.Instance.playersInTeam.Count;

        for(int i = 0; i < totalNum; i++)
        {
            GameObject playerClone = ObjectPool.objPool.GetObjectFromPool();

            if(playerClone)
            {
                GameManager.Instance.playersInTeam.Add(playerClone);
                playerClone.GetComponent<Player>().PlayerPositioning();
            } 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnTouchIncreaser();
            IncreasePlayerCount();
            GameManagerCheck();
        }
        
    }
}
