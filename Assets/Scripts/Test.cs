using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public enum ETest
{
    Flag,
    A,
    B,
    All,
    C
}

public class Test : SerializedMonoBehaviour
{
    [BoxGroup]
    [EnumToggleButtons]
    public ETest etest;
    public Dictionary<int, GameObject> num;
    public int[] index;
    public AudioSource musicSource;
    [ShowInInspector]
    [ValueDropdown("musicList")]
    
    [InlineButton("PlayMusic","play")]
    private AudioClip _currentMusicClip;
    [InlineEditor(InlineEditorModes.SmallPreview)]
    public List<AudioClip> musicList;
    [BoxGroup]
    
    public double id;
    public static void Message(String message="message")
    {
        print(message);
    }
    public void PlayMusic(AudioClip music)
    {
       print(music);
        if(musicSource.clip != null && music != null)
        { 
            print("play");
            musicSource.clip = music;
            musicSource.Play();
        }
    }
}
