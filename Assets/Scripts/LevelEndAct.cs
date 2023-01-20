using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndAct : MonoBehaviour
{
    [SerializeField] GameObject playerParent;
    float yOffset = 3.9f;
    float xOffset = 1.8f;
    float startYPoint = 0;
    float startXPoint = 0;
    int PlayerInRowInTower = 1;
    void Start()
    {
        
    }

    public void MakingTower()
    {
        int playerCount = GameManager.Instance.playersInTeam.Count;
        AllPlayersParentNull();

        while(playerCount > 0)
        {
            
            for (int i = 0; i < PlayerInRowInTower; i++)
            {
                playerCount--;
                Vector3 newPos = new Vector3(playerParent.transform.localPosition.x,startYPoint,playerParent.transform.localPosition.z);
                playerParent.transform.localPosition = newPos;
                // MoveToPosition(GameManager.Instance.playersInTeam[playerCount],
                //                 new Vector3(startXPoint,0,playerParent.transform.position.z));
                GameManager.Instance.playersInTeam[playerCount].transform.localPosition = new Vector3(startXPoint,0,playerParent.transform.position.z);
                GameManager.Instance.playersInTeam[playerCount].transform.parent = playerParent.transform;
                GameManager.Instance.playersInTeam[playerCount].name = i.ToString();
                
                startXPoint += xOffset;
                
            }
            PlayerInRowInTower += 2;
            startXPoint = (xOffset * (PlayerInRowInTower)) / (-2);
            startYPoint += yOffset;
            
            
            // if(PlayerInRowInTower >= 13)
            // {
            //     PlayerInRowInTower = 13;
            //     if(playerCount < 13)
            //         break;
            // }
                
            if(playerCount < PlayerInRowInTower)
                PlayerInRowInTower = playerCount;
        }
        
        
    }

    void AllPlayersParentNull()
    {
        for (int i = 0; i < GameManager.Instance.playersInTeam.Count; i++)
        {
            GameManager.Instance.playersInTeam[i].transform.parent = null;
        }
    }

    void MoveToPosition(GameObject obj,Vector3 targetPos)
    {
        StartCoroutine(MoveToPositionRoutine(obj,targetPos));
    }

    IEnumerator MoveToPositionRoutine(GameObject obj,Vector3 targetPos)
    {
        bool canReach = false;
        float elapsedTime = 0;
        while(!canReach)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime/2);
            obj.transform.position = Vector3.Lerp(obj.transform.localPosition,targetPos,t);

            if(Vector3.Distance(obj.transform.position,targetPos) < 0.01f)
                canReach = true;
        }
    }
}
