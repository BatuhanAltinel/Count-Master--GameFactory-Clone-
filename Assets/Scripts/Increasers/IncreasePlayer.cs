using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IncreasePlayer : MonoBehaviour
{
    public int increaseAmount;
    public virtual void IncreasePlayerCount()
    {
        
    }
    public void OnTouch()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        gameObject.SetActive(false);
        IncreasePlayerCount();
        GameManager.Instance.UpdatePlayerCountText();
    }

}
