using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayer : MonoBehaviour
{
    public int len = 10;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.SetActive(false);
            IncreasePlayerCount();
            GameManager.Instance.MoveAllTeamToMiddle();
        }   
    }

    void IncreasePlayerCount()
    {
        for(int i =0; i < len; i++)
        {
            GameObject playerClone = ObjectPool.objPool.GetObjectFromPool();

            if(playerClone)
            {
                GameManager.Instance.playersInTeam.Add(playerClone);
                // playerClone.GetComponent<Player>().PlayerPositioning();
            }
                
            
        }
    }
}
