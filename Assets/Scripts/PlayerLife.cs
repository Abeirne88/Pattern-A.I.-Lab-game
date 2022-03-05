using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    //to add the sound file to the death

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            //if player collides with object having the trap tag
        {
            Die();
            //u die
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        //play sound
        rb.bodyType = RigidbodyType2D.Static;
        //so it stops moving after death
        anim.SetTrigger("death");
        //sets the death animation
    }
   
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //loads current level
    }
}
