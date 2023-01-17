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
            enemies[i].transform.rotation = Quaternion.LookRotation(playerTransform.position);
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
            gameObject.SetActive(false);
        }
    }
     void RunToPlayer()
    {
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime * 3f);

        // for (int i = 0; i < enemies.Count; i++)
        // {
        //     enemies[i].GetComponent<Enemy>().RunTo();
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

        }
    }
}
