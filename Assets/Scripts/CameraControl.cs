using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private Vector3 _offset;
    private Vector3 _pos;
    public float speed = 2;
    private void Start()
    {
        _offset =  transform.position - target.position;
    }
    void LateUpdate()
    {
        _pos = target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _pos, speed * Time.deltaTime);//调整相机与玩家之间的距离
    }
}
