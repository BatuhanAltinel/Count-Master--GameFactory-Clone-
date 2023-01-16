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
        // if(GameManager.Instance.gameState == GameManager.GameStates.START)
        //     PlayWalkAnim();
        // else
        //     PlayIdleAnim();
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
        // StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine()
    {
        gameObject.transform.parent = null;
        PlayIdleAnim();
        yield return new WaitForSeconds(0.1f);

        ObjectPool.objPool.ReturnToPool(this.gameObject);
        GameManager.Instance.playersInTeam.Remove(this.gameObject);
    }

    public void MoveToMiddle()
    {
        StartCoroutine(MoveToMiddleRoutine());
    }

    IEnumerator MoveToMiddleRoutine()
    {
        bool moving = true;
        float timer = 0;
        while(moving)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition,new Vector3(0f,0f,0f),0.05f);
            if(timer > 1f)
            {
                moving = false;
            }
                
            
        }
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LeftBorder"))
        {
            GameManager.Instance.canMoveLeft = false;
        }
        if(other.CompareTag("RightBorder"))
        {   
            GameManager.Instance.canMoveRight = false;
        }
    }

}
