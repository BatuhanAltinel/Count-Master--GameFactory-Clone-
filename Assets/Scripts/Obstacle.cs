using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // ObjectPool.objPool.ReturnToPool(other.gameObject);
            other.GetComponent<Player>().Die();
            GameManager.Instance.MoveAllTeamToMiddle(0.1f);
        }
    }
}
