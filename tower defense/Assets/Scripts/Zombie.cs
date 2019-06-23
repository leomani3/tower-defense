using UnityEngine;
using UnityEngine.AI;


//cette classe est la classe parente de tout les enemies
public class Zombie : Unit
{
    //-------VARIABLES-------
    public float speed = 3.5f;  //vitesse de déplacement
    public float sightDistance = 1f;    //distance de vision

    protected GameObject target = null;   //Correspond au player ou batiment que le zombie vise s'il y en a un à portée "sightdistance"
    protected int nbEnemiesInSight = 0;

    //---------COMPONENTS---------
    protected NavMeshAgent navMeshAgent;
    protected SphereCollider sphereCollider;
    private Transform playerBase;


    /// <summary>
    /// A appelé au Start();
    /// </summary>
    protected void Setup()
    {
        //On change la taille de la sphere collider qui gère la vision du zombie en fonction de la valeur de "SightDistance"
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = sightDistance;

        //On change la vitesse du NavMeshAgent en fonction de la valeur de "speed"
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;

        //On set le premier waypoint
        if (GameObject.Find("Player Base") != null)
        {
            playerBase = GameObject.Find("Player Base").transform;
        }
    }

    /// <summary>
    /// Utilise le navmesh pour faire avancer le zombie jusqu'à la playerBase
    /// </summary>
    protected void Move()
    {
        //Déplacement vers la base enemie
        if(playerBase != null)
        {
            navMeshAgent.SetDestination(playerBase.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null && other.tag != "Base")
        {
            nbEnemiesInSight++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null && other.tag != "Base")
        {
            nbEnemiesInSight--;
            if (nbEnemiesInSight == 0)
            {
                target = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null && other.tag != "Base")
        {
            if (target == null)
            {
                target = other.gameObject;
            }
            else if (Vector3.Distance(transform.position, other.transform.position) < Vector3.Distance(transform.position, target.transform.position))
            {
                target = other.gameObject;
            }
        }
    }
}
