/******************************************
 * 
 * FileName:     Background
 * CompanyName:  MiniGame
 * Author:       iCoove
 * CreateTime:   2022-12-28-22:17:08
 * UnityVersion: 2021.3.10f1c2
 * Version：     1.0
 * Description:
 * 
******************************************/

using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace FlappyBird
{
 public class Background : MonoBehaviour
 {
     public GameObject spawnPoint;
     public GameObject wall;
     private Vector3 _finalPoint;
     private void Start()
     {
         StartCoroutine(SpawnWall());
     }

     private IEnumerator SpawnWall()
     {
         while (true)
         {
             Vector3 offset = new Vector3(0, Random.Range(-3.0f, 3.0f), 0);
             GameObject obstacle =Instantiate(wall, spawnPoint.transform);
             obstacle.transform.position += offset;
             yield return new WaitForSeconds(2);
         }
         // ReSharper disable once IteratorNeverReturns
     }
 }
}
