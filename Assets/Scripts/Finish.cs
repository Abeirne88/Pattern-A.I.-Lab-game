using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    //theres a finish sound file

    private bool levelCompleted = false;
    //is the level complete, original is false 

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        //gets the finish sound file 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
            //if the player collides and the level is complete
        {
            finishSound.Play();
            //play sound
            levelCompleted = true;
            //level bool is true after colliding with the flag
            //also cant continue to run around level in the waiting period
            Invoke("CompleteLevel", 2f);
            //waits 2 seconds before loading the next level
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //uses the scene manager to load the next level
}
