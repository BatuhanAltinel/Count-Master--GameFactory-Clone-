using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    [SerializeField] Transform followTransform;
    [SerializeField] Vector3 offSet;
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,followTransform.position + offSet,1f * Time.deltaTime);
    }
}
