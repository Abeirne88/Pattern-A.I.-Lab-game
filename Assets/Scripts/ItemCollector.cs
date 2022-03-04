using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    //zero cherries 

    [SerializeField] private Text cherriesText;
    //in case need to edit it later in the editor

    //[SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
        //when it collides
    {
        if (collision.gameObject.CompareTag("Cherry"))
            //if it collides with cherry tag
        {
            //collectionSoundEffect.Play();
            //play sound
            Destroy(collision.gameObject);
            //destriy object
            cherries++;
            //add 1 to cherries
            Debug.Log("Cherries: ");
            cherriesText.text = "Cherries: " + cherries;
            //cherries goes up
        }
    }
}
