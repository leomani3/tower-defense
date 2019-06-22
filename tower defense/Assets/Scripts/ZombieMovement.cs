using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2.0f;

    private Transform target;
    private int waypointIndex = 0;
    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = WaypointManager.waypoints[0];
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        //Si le zombie est arrivé au waypoint courant, il prend le suivant
        if(Vector3.Distance(transform.position, target.position) < 0.3)
        {
            getNextWaypoint();
        }

        //Déplacement vers la cible via le navmesh
        navMeshAgent.SetDestination(target.position);
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
