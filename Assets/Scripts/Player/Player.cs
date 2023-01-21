using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    [SerializeField] ParticleSystem splashParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void PlayWalkAnim()
    {
        anim.SetBool("IsWalk",true);
    }

    public void PlayIdleAnim()
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
            if(timer > 0.05f)
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
        if(other.CompareTag("EnemyParent"))
        {
            GameManager.Instance.gameState = GameManager.GameStates.ATTACK;
            GameManager.Instance.targetTransform = other.gameObject.transform;
            GameManager.Instance.LookAtThe(GameManager.Instance.targetTransform.position);
        }
        if(other.CompareTag("Space"))
        {
            Die();
        }
        if(other.CompareTag("Finish"))
        {
            GameManager.Instance.gameState = GameManager.GameStates.WIN;
            GameManager.Instance.AllTeamPlayIdleAnim();
            GameManager.Instance.LevelEnding();
            UIManager.instance.DeActivePlayerCountCanvas();
        }
        if(other.CompareTag("EndCube"))
        {
            transform.parent = null;
            PlayIdleAnim();
            GameManager.Instance.playersInTeam.Remove(gameObject);
            if(GameManager.Instance.playersInTeam.Count <= 0)
            {
                GameManager.Instance.gameState = GameManager.GameStates.WIN;
                UIManager.instance.WinPanelActivation();
            }
        }
        if(other.CompareTag("Won"))
        {
            PlayIdleAnim();
            GameManager.Instance.gameState = GameManager.GameStates.WIN;
            UIManager.instance.WinPanelActivation();
        }
    }

}
