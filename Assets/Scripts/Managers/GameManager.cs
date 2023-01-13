using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public enum GameStates{
        START,
        STOP,
        END,
        WİN,
        LOSE
    }
    public GameStates gameState;
    public static GameManager Instance;
    public GameObject firstPlayer;
    public List<GameObject> playersInTeam = new List<GameObject>();

    public TextMeshProUGUI playerCountText;
    public bool canMoveRight;
    public bool canMoveLeft;
    public bool isTouchedInteractable = true;
    float positioningRandomRadius = .9f;

    public float GetRandomRadius{
        get{return Random.Range(-positioningRandomRadius,positioningRandomRadius);} 
        set{ positioningRandomRadius = value;}}

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        canMoveRight = true;
        canMoveLeft = true;
        gameState = GameStates.STOP;
        playersInTeam.Add(firstPlayer);
    }

    public void UpdatePlayerCountText()
    {
        playerCountText.text = playersInTeam.Count.ToString();
    }

    public void CheckGameOver()
    {
        if(GameManager.Instance.playersInTeam.Count <= 0)
            Time.timeScale = 0;
    }
    public void MoveAllTeamToMiddle(float timeToWait)
    {
        if(isTouchedInteractable)
            StartCoroutine(MoveAllTeamToMiddleRoutine(timeToWait));
    }

    IEnumerator MoveAllTeamToMiddleRoutine(float timeToWait)
    {
        isTouchedInteractable = false;
        yield return new WaitForSeconds(timeToWait);
        
        for (int i = 0; i < playersInTeam.Count; i++)
        {
            playersInTeam[i].GetComponent<Player>().MoveToMiddle();
        }
        isTouchedInteractable = true;
    }
}
