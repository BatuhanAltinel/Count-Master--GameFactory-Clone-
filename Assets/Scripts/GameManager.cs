using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool canMoveRight;
    public bool canMoveLeft;
    float positioningRandomRadius = .0f;

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

    public void MoveAllTeamToMiddle()
    {
        StartCoroutine(MoveAllTeamToMiddleRoutine());
    }

    IEnumerator MoveAllTeamToMiddleRoutine()
    {
        // yield return new WaitForSeconds(0.5f);
        yield return null;
        for (int i = 0; i < playersInTeam.Count; i++)
        {
            playersInTeam[i].GetComponent<Player>().MoveToMiddle();
        }
    }
}
