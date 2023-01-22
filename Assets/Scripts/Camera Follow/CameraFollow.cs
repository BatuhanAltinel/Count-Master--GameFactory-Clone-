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
        moveSpeed = 1.2f;
    }

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
        offSet = new Vector3(0,27.3f,-20.6f);
        transform.position = Vector3.Lerp(transform.position,followTransform.position + offSet,moveSpeed * Time.deltaTime);
    }
    void OnAttackCameraFollow()
    {
        onAttackOffset = new Vector3(0,18,-19.6f);
        transform.position = Vector3.Lerp(transform.position,followTransform.position + onAttackOffset,moveSpeed * Time.deltaTime);
    }
    void OnEndLevelFollow()
    {
        endLevelRot = Quaternion.Euler(33.1f,281.9f,0);
        onLevelEndOffset = new Vector3(46.5f,37.8f,-10.5f);

        moveSpeed = 8f;
        transform.position = Vector3.Lerp(transform.position,followTransform.position + onLevelEndOffset,moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation,endLevelRot,0.05f);
    }
}
