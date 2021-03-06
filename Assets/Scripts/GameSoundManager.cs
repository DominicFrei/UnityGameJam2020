﻿using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class GameSoundManager : MonoBehaviour
{
    private static GameSoundManager _instance;

    public static GameSoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameSoundManager>();
            }

            return _instance;
        }
    }

    public AudioClip StarLiftoffClip;

    public AudioSource audioSource;
    private void Awake()
    {
       
        int numMusicPlayers = FindObjectsOfType<GameSoundManager>().Length;
        if (numMusicPlayers > 1)
        {
            print("Destroying Game Sound Manager");
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayStarLiftoffSound()
    {
        audioSource.PlayOneShot(StarLiftoffClip);
    }

}
