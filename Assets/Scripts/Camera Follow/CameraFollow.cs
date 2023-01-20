using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    [SerializeField] Transform followTransform;
    [SerializeField] Vector3 offSet;
    [SerializeField] Vector3 onAttackOffset;
    [SerializeField] Vector3 onLevelEndOffset;
    [SerializeField] Quaternion endLevelRot;
    [SerializeField] float moveSpeed = 1.2f;
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.START)
            CameraNormalFollow();
        else if(GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
            OnAttackCameraFollow();
        else if(GameManager.Instance.gameState == GameManager.GameStates.WIN || 
                GameManager.Instance.gameState == GameManager.GameStates.END)
            OnEndLevelFollow();
    }

    void CameraNormalFollow()
    {
        // offSet = new Vector3(0,27.3f,-20.6f);
        transform.position = Vector3.Lerp(transform.position,followTransform.position + offSet,moveSpeed * Time.deltaTime);
    }
    void OnAttackCameraFollow()
    {
        // onAttackOffset = new Vector3(0,18,-19.6f);
        transform.position = Vector3.Lerp(transform.position,followTransform.position + onAttackOffset,moveSpeed * Time.deltaTime);
    }
    void OnEndLevelFollow()
    {
        // endLevelRot = Quaternion.Euler(27.6f,-80f,0);
        // onLevelEndOffset = new Vector3(35.2f,21.7f,-7f);

        transform.position = Vector3.Lerp(transform.position,followTransform.position + onLevelEndOffset,moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation,endLevelRot,0.05f);
    }
}
