using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Audio;

public class MiddleScript : MonoBehaviour
{
    public LogicScript logic;
    private int Gamepoint = 1;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>();
        //AudioClip sound = logic.soundEffect
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LogicScript.levelup = true;
        if (collision.gameObject.layer == 3)
        {
            audioSource.PlayOneShot(logic.soundEffect);
            logic.add(Gamepoint);
        }
    }
}
