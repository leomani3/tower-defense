using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 3.5f;
    public float sightDistance = 1f;
    public float distanceAttack = 3f;

    private Transform currentWaypoint;
    private GameObject target = null;
    private int waypointIndex = 0;
    private NavMeshAgent navMeshAgent;
    private SphereCollider sphereCollider;
    //premet de compter le nombre d'enemies dans le champ de vision du zombie
    private int nbEnemiesInSight = 0;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = sightDistance;

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;

        currentWaypoint = WaypointManager.waypoints[0];
    }

    private void Update()
    {
        //Si le zombie est arrivé au waypoint courant, il prend le suivant
        if(target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
            if (Vector3.Distance(transform.position, target.transform.position) < distanceAttack)
            {
                Debug.Log("ATTACK");
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.5)
            {
                getNextWaypoint();
            }

            //Déplacement vers la cible via le navmesh
            navMeshAgent.SetDestination(currentWaypoint.position);
        }
    }

    private void getNextWaypoint()
    {
        if(waypointIndex < WaypointManager.waypoints.Length - 1)
        {
            waypointIndex++;
            currentWaypoint = WaypointManager.waypoints[waypointIndex];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            nbEnemiesInSight++;
            Debug.Log("nombre de cible en vue : "+nbEnemiesInSight);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nbEnemiesInSight--;
            Debug.Log("nombre de cible en vue : " + nbEnemiesInSight);
            if (nbEnemiesInSight == 0)
            {
                target = null;
                Debug.Log("Plus aucune cible");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(target == null)
            {
                target = other.gameObject;
                Debug.Log("Première cible : " + other.name);
            }
            else if(Vector3.Distance(transform.position, other.transform.position) < Vector3.Distance(transform.position, target.transform.position))
            {
                target = other.gameObject;
                Debug.Log("Nouvelle cible : " + other.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, distanceAttack);
    }
}
