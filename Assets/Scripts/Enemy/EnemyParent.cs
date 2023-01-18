using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnemyParent : MonoBehaviour
{
    public List<GameObject> enemies;
    public TextMeshProUGUI enemyCountText;
    public Transform playerTransform;

    void Awake()
    {
        enemyCountText.text = enemies.Count.ToString();
    }
    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
        {
            RunToPlayer();
            LookAtThe();
        }
            
    }

    private void LookAtThe()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].transform.LookAt(playerTransform.position);
        }
    }

    public void UpdatePlayerCountText()
    {
        enemyCountText.text = enemies.Count.ToString();
    }
    public void CheckForDefeat()
    {
        if(enemies.Count <= 0)
        {
            GameManager.Instance.gameState = GameManager.GameStates.START;
            GameManager.Instance.MoveAllTeamToMiddle(0.1f);
            gameObject.SetActive(false);
        }
    }
     void RunToPlayer()
    {
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime * 4f);
    }

}
