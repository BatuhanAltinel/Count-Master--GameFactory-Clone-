using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndAct : MonoBehaviour
{
    [SerializeField] GameObject playerParent;
    [SerializeField] GameObject EndLine;
    float yOffset = 3.9f;
    float xOffset = 1.8f;
    float startYPoint = 0;
    float startXPoint = 0;
    int PlayerInRowInTower = 1;

    public void MakingTower()
    {
        StartCoroutine(MakingTowerRoutine());
    }

    IEnumerator MakingTowerRoutine()
    {
        int playerCount = GameManager.Instance.playersInTeam.Count;
        AllPlayersParentNull();
        
        yield return new WaitForSeconds(2f);
        while(playerCount > 0)
        {
            
            for (int i = 0; i < PlayerInRowInTower; i++)
            {
                playerCount--;
                Vector3 newPos = new Vector3(playerParent.transform.localPosition.x,startYPoint,playerParent.transform.localPosition.z);
                playerParent.transform.localPosition = newPos;

                Vector3 targetPos = new Vector3(startXPoint,0,playerParent.transform.position.z);
                
                    GameManager.Instance.playersInTeam[playerCount].transform.position = Vector3.Lerp(
                    GameManager.Instance.playersInTeam[playerCount].transform.position,
                    targetPos,5f);
                    yield return new WaitForEndOfFrame();
                

                GameManager.Instance.playersInTeam[playerCount].transform.parent = playerParent.transform;
                GameManager.Instance.playersInTeam[playerCount].name = i.ToString();
                
                startXPoint += xOffset;
            }
            PlayerInRowInTower += 2;
            startXPoint = (xOffset * (PlayerInRowInTower)) / (-2);
            startYPoint += yOffset;
            yield return new WaitForSeconds(0.1f);

            if(playerCount < PlayerInRowInTower)
            {
                PlayerInRowInTower = playerCount;
                for (int i = 0; i < PlayerInRowInTower; i++)
                {
                    playerCount--;
                    ObjectPool.objPool.ReturnToPool(GameManager.Instance.playersInTeam[playerCount]);
                    GameManager.Instance.playersInTeam.Remove(GameManager.Instance.playersInTeam[playerCount]);
                }
                
            }
        }
        RunToWalls();
    }


    void AllPlayersParentNull()
    {
        for (int i = 0; i < GameManager.Instance.playersInTeam.Count; i++)
        {
            GameManager.Instance.playersInTeam[i].transform.parent = null;
        }
    }

    void RunToWalls()
    {
        EndLine.GetComponent<BoxCollider>().enabled = false;
        GameManager.Instance.AllTeamPlayWalkAnim();
        GameManager.Instance.gameState = GameManager.GameStates.END;
    }

}
