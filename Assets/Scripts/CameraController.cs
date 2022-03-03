using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    //lets me add the player to be followed

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //uses the transform coords to follow the player
    }
}
