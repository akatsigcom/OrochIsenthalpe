using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANQ_PicVert : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;      // place the points the bird will go to

    [SerializeField]
    private float moveSpeed = 2f;

    private int waypointIndex = 0;
    private bool canFly = false;
    public static Vector3 lastPos;


    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position; // place bird first waypoint
        lastPos = waypoints[waypoints.Length-1].transform.position;
    }

    private void Update()       // bird can move at each word found
    {
        Move();
        if (CodageMorse.displayResult)
        {
            canFly = true;
        }
    }

    private void Move()     // bird is stopped a certain waypoints
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (canFly)
                {
                    waypointIndex += 1;
                    if (waypointIndex==4 ^ waypointIndex == 8 ^ waypointIndex == 12)
                    {
                        canFly = false;
                    }
                }
            }
        }

    }
}
