using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2.0f;

    private Transform target;
    private int waypointIndex = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = WaypointManager.waypoints[0];
    }

    private void FixedUpdate()
    {
        //Si le zombie est arrivé au waypoint courant, il prend le suivant
        if(Vector3.Distance(transform.position, target.position) < 0.1)
        {
            getNextWaypoint();
        }

        //le zombie regarde en direction du waypint en tout temps et avance tout droit
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        rb.MovePosition(transform.position + (transform.forward * speed * Time.fixedDeltaTime));
    }

    private void getNextWaypoint()
    {
        if(waypointIndex < WaypointManager.waypoints.Length - 1)
        {
            waypointIndex++;
            target = WaypointManager.waypoints[waypointIndex];
        }
    }
}
