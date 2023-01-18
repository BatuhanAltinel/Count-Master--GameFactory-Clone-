using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    Vector3 runPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        runPos = Vector3.zero;
    }

    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
        {
            PlayWalkAnim();
        }
    }
    void PlayWalkAnim()
    {
        anim.SetBool("IsWalk",true);
    }

    void Die()
    {
        gameObject.SetActive(false);
        transform.GetComponentInParent<EnemyParent>().enemies.Remove(gameObject);
        transform.GetComponentInParent<EnemyParent>().UpdatePlayerCountText();
        transform.GetComponentInParent<EnemyParent>().CheckForDefeat();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Die();
            other.gameObject.GetComponent<Player>().Die();
            runPos = other.transform.parent.position;
        }
    }
}
