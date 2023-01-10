using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    PlayerMovement playerMovement;

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
    }

    void PlayWalkAnim()
    {
        anim.SetBool("IsWalk",true);
    }

    void PlayIdleAnim()
    {
        anim.SetBool("IsWalk",false);
    }
}
