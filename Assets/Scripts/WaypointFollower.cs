using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    //so i can select the moving platforms in unity and how many i want there to be
    private int currentWaypointIndex = 0;
    //keeps the number of what waypoint there at

    [SerializeField] private float speed = 2f;
    //speed of it

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            //calcs the distance between the current waypoint and the platform
            //finds the index and sees if it near enough and swaps
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
                //if its at the last index it resets it back to 0 to go again
            {
                currentWaypointIndex = 0;
                //back to zero
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        //move towards the oposite waypoint by transforming the position
        //moves per frame rate
    }
}
