using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objPool;
    public GameObject playerPrefab;
    public GameObject playerParent;
    Queue<GameObject> playerQueue = new Queue<GameObject>();
    public int amountOfPlayer = 100;
    void Awake()
    {
        if(objPool == null)
            objPool = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        FirstCreate();
    }

    void FirstCreate()
    {
        for (int i = 0; i < amountOfPlayer; i++)
        {
            GameObject playerClone = Instantiate(playerPrefab,transform.position,Quaternion.identity);
            playerQueue.Enqueue(playerClone);
            playerClone.transform.parent = playerParent.transform;
            playerClone.SetActive(false);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject playerClone in playerQueue)
        {
            if(!playerClone.activeInHierarchy)
            {
                playerClone.SetActive(true);
                playerQueue.Dequeue();
                return playerClone;
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        playerQueue.Enqueue(obj);
    }
}
