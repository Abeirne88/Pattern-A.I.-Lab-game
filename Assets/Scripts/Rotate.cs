using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    //to change the speed in unity

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        //only rotates it on z axis 360 degrees per frame
    }
}
