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
            other.GetComponent<Player>().Die();
            GameManager.Instance.UpdatePlayerCountText();
            GameManager.Instance.CheckGameOver();
        }
    }
}
