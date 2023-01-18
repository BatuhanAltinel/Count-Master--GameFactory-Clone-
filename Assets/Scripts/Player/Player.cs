using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckOnGround();
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
        GameManager.Instance.UpdatePlayerCountText();
        GameManager.Instance.CheckGameOver();
        // StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine()
    {
        gameObject.transform.parent = null;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        // play particle
        yield return new WaitForSeconds(0.2f);

        ObjectPool.objPool.ReturnToPool(this.gameObject);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
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

    void CheckOnGround()
    {
        if(transform.position.y < -5f)
            Die();
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
        if(other.CompareTag("EnemyParent"))
        {
            GameManager.Instance.gameState = GameManager.GameStates.ATTACK;
            GameManager.Instance.targetTransform = other.gameObject.transform;
            GameManager.Instance.LookAtThe();
        }
        if(other.CompareTag("Space"))
        {
            // gameObject.transform.parent = null;
            // GameManager.Instance.playersInTeam.Remove(gameObject);
            // rb.AddForce(Vector3.down * 1000f * Time.deltaTime,ForceMode.Impulse);
            Die();
        }
    }

}
