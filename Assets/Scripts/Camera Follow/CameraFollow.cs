using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    [SerializeField] Transform followTransform;
    [SerializeField] Vector3 offSet;
    [SerializeField] float moveSpeed = 1.2f;
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,followTransform.position + offSet,moveSpeed * Time.deltaTime);
    }
}
