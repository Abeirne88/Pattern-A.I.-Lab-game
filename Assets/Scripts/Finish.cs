using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    //theres a finish sound file

    private bool levelCompleted = false;
    //is the level complete

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
            //level bool is true
            Invoke("CompleteLevel", 2f);
            //
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //
}
