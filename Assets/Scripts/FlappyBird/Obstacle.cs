/******************************************
 * 
 * FileName:     Obstacle
 * CompanyName:  MiniGame
 * Author:       iCoove
 * CreateTime:   2022-12-28-22:27:29
 * UnityVersion: 2021.3.10f1c2
 * Version：     1.0
 * Description:
 * 
******************************************/

using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FlappyBird
{
 public class Obstacle : MonoBehaviour
 {
     public float speed=3f;

     private void Start()
     {
         Destroy(gameObject,5);
     }

     private void Update()
     {
         transform.Translate(Vector3.left*speed,Space.World);
     }
 }
}
