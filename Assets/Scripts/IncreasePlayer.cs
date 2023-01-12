using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayer : MonoBehaviour
{
    [SerializeField] int increaseAmount;
    [SerializeField] string processName;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log(GameManager.Instance.playersInTeam.Count);
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.SetActive(false);
            IncreasePlayerCount();
            GameManager.Instance.UpdatePlayerCountText();
            GameManager.Instance.MoveAllTeamToMiddle(0);
        }   
    }

    void IncreasePlayerCount()
    {
        if(processName == "+")
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
        if(processName == "x")
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
        
    }
}
