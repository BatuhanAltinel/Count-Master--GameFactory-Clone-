using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    PlayerMovement playerMovement;

    void Start()
    {
        anim = GetComponent<Animator>(); 
        playerMovement = GetComponentInParent<PlayerMovement>();  
        
    }

    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.START)
            PlayWalkAnim();
        else
            PlayIdleAnim();
    }

    public void PlayWalkAnim()
    {
        anim.SetBool("IsWalk",true);
    }

    void PlayIdleAnim()
    {
        anim.SetBool("IsWalk",false);
    }

    public void PlayerPositioning()
    {
        float zMove =  GameManager.Instance.GetRandomRadius;
        float xMove =  GameManager.Instance.GetRandomRadius;
        Vector3 newPos = new Vector3(xMove,0,zMove);
        transform.localPosition = newPos;
    }
    
    public void Die()
    {
        ObjectPool.objPool.ReturnToPool(this.gameObject);
        GameManager.Instance.playersInTeam.Remove(this.gameObject);
    }

    public void MoveToMiddle()
    {
        StartCoroutine(MoveToMiddleRoutine());
    }

    IEnumerator MoveToMiddleRoutine()
    {
        Transform parent = transform.parent;
        bool moving = true;
        float timer = 0;
        while(moving)
        {
            timer += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition,new Vector3(0,0,0),0.2f);
            if(timer > 0.5)
            {
                moving = false;
            }
                
            yield return new WaitForEndOfFrame();
        }
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LeftBorder"))
        {
            GameManager.Instance.canMoveLeft = false;
            GameManager.Instance.canMoveRight = true;
            Debug.Log("Left border touched");
        }
        if(other.CompareTag("RightBorder"))
        {
            GameManager.Instance.canMoveLeft = true;
            GameManager.Instance.canMoveRight = false;
            Debug.Log("right border touched");
        }
    }
    
    // void OnTriggerExit(Collider other)
    // {
    //     if(other.CompareTag("LeftBorder") || other.CompareTag("RightBorder"))
    //     {
    //         GameManager.Instance.canMoveLeft = true;
    //         GameManager.Instance.canMoveRight = true;
    //         Debug.Log("border exited");
    //     }
    // }


}
