using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    PlayerMovement playerMovement;

    float xBoundary = 9.5f;
    public GameObject startPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        playerMovement = GetComponentInParent<PlayerMovement>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.canMove)
            PlayWalkAnim();
        else
            PlayIdleAnim();
        
        BoundaryChechk();
        Debug.Log( playerMovement.canMoveRight);
    }

    void PlayWalkAnim()
    {
        anim.SetBool("IsWalk",true);
    }

    void PlayIdleAnim()
    {
        anim.SetBool("IsWalk",false);
    }
    
    public void PlayerPositioning()
    {

    }
    void BoundaryChechk()
    {
        if(transform.position.x > xBoundary || transform.position.x < -xBoundary)
        {
            playerMovement.canMoveRight = false;
        }
    }



}
