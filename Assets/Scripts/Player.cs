using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    PlayerMovement playerMovement;
    [SerializeField] Transform leftCheckPoint;
    [SerializeField] Transform rightCheckPoint;
    bool LeftHit;
    bool rightHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
        playerMovement = GetComponentInParent<PlayerMovement>();  
    }

    void Update()
    {
        if(GameManager.gameManager.canMove)
            PlayWalkAnim();
        else
            PlayIdleAnim();
        
        
        // ImpulseToGround();
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
        float zMove = Random.Range(-2,2);
        float xMove = Random.Range(-2,2);
        Vector3 newPos = new Vector3(xMove,0,zMove);
        transform.localPosition = newPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LeftBorder"))
        {
            GameManager.gameManager.canMoveLeft = false;
            GameManager.gameManager.canMoveRight = true;
            Debug.Log("Left border touched");
        }
        if(other.CompareTag("RightBorder"))
        {
            GameManager.gameManager.canMoveLeft = true;
            GameManager.gameManager.canMoveRight = false;
            Debug.Log("right border touched");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("LeftBorder"))
        {
            GameManager.gameManager.canMoveLeft = false;
            GameManager.gameManager.canMoveRight = false;
            Debug.Log("Left border exited");
        }
        if(other.CompareTag("RightBorder"))
        {
            GameManager.gameManager.canMoveLeft = false;
            GameManager.gameManager.canMoveRight = false;
            Debug.Log("right border exited");
        }
    }


}
