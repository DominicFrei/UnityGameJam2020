﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    public AudioClip enemyBumpSound;
    public AudioClip playerBumpSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // lookDirection stores the Vector3 direction that 
        // the enemy should move towards the the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Move the enemy towards the player based off a set speed
        enemyRb.AddForce(lookDirection * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            TransitionManager.TransitionTo(TransitionManager.Transition.FromRoom2);
            playerAudio.PlayOneShot(playerBumpSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(enemyBumpSound, 1.0f);
        }
    }

}
