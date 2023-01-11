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
        }   
    }

    void IncreasePlayerCount()
    {
        for(int i =0; i < len; i++)
        {
            GameObject playerClone = ObjectPool.objPool.GetObjectFromPool();
            if(playerClone)
            {
                // playerClone.transform.localPosition = Vector3.zero;
                playerClone.GetComponent<Player>().PlayerPositioning();
            }
                
            
        }
    }
}
