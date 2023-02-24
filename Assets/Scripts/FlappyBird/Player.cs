/******************************************
 * 
 * FileName:     player
 * CompanyName:  MiniGame
 * Author:       iCoove
 * CreateTime:   2022-12-28-19:33:59
 * UnityVersion: 2021.3.10f1c2
 * Version：     1.0
 * Description:
 * 
******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FlappyBird
{
 public class Player : MonoBehaviour
 {
     public GameObject player;
     public float upSpeed=1;
     private Animator _pAnimator;
     private Rigidbody2D _pRigid;
     private void Awake()
     {
         _pAnimator = player.GetComponent<Animator>();
         _pRigid = player.GetComponent<Rigidbody2D>();
     }

     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             _pAnimator.SetTrigger("UP");
            _pRigid.velocity = new Vector2(0, upSpeed);
         }

         
     }
 }
}
