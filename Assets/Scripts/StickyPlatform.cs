using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            //if collinding with player 
        {
            collision.gameObject.transform.SetParent(transform);
            //set it to a child of the moving platform
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            //if collinding with player 
        {
            collision.gameObject.transform.SetParent(null);
            //set it to null so its no longer a child
        }
    }
}
