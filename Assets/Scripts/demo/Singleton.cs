/******************************************
 * 
 * FileName:     Singleton
 * CompanyName:  MiniGame
 * Author:       iCoove
 * CreateTime:   2023-02-03-08:47:39
 * UnityVersion: 2021.3.10f1c2
 * Version：     1.0
 * Description:
 * 
******************************************/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:Singleton<T>
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).ToString();
            DontDestroyOnLoad(obj);
            instance = obj.AddComponent<T>();
        }
        return instance;
    }
}
