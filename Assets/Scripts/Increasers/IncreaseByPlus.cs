using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseByPlus : IncreasePlayer
{

   
    void Start()
    {

    }
    public override void IncreasePlayerCount()
    {
        for(int i =0; i < increaseAmount; i++)
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
        if (other.CompareTag("Player"))
        {
            OnTouchIncreaser();    
            IncreasePlayerCount();
            GameManagerCheck();
        }
        
    }
}
