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
    }
    
    public void RunTo()
    {
        Vector3 dir = (transform.position - runPos).normalized;
        transform.localPosition = Vector3.Lerp(transform.position,runPos,0.1f);
        Debug.Log(runPos);
        // transform.Translate(dir * Time.deltaTime * 0.2f);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Die();
            // play particle
            transform.GetComponentInParent<EnemyParent>().enemies.Remove(gameObject);
            transform.GetComponentInParent<EnemyParent>().UpdatePlayerCountText();
            transform.GetComponentInParent<EnemyParent>().CheckForDefeat();
            other.gameObject.GetComponent<Player>().Die();
            GameManager.Instance.UpdatePlayerCountText();
            GameManager.Instance.CheckGameOver();
            runPos = other.transform.parent.position;
        }
    }
}
