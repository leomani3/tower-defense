using UnityEngine;
using UnityEngine.AI;


//cette classe est la classe parente de tout les enemies
public class Zombie : Unit
{
    //-------VARIABLES-------
    public float speed = 3.5f;  //vitesse de déplacement
    public float sightDistance = 1f;    //distance de vision
    public float distanceAttack = 3f;   //distance d'attaque

    protected GameObject target = null;   //Correspond au player ou batiment que le zombie vise s'il y en a un à portée "sightdistance"
    protected int nbEnemiesInSight = 0;

    //---------COMPONENTS---------
    protected NavMeshAgent navMeshAgent;
    protected SphereCollider sphereCollider;
    protected float timeBetweenAttacks;
    protected float timeCount=0;
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
        playerBase = GameObject.Find("Player Base").transform;
    }

    /// <summary>
    /// Regarde si "target" est assez proche pour être tapée
    /// </summary>
    protected bool CheckDistanceAttack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < distanceAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Utilise le navmesh pour faire avancer le zombie jusqu'à la playerBase
    /// </summary>
    protected void Move()
    {
        //Déplacement vers la base enemy
        if(playerBase != null)
        {
            navMeshAgent.SetDestination(playerBase.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null)
        {
            nbEnemiesInSight++;
            Debug.Log("LBLBL");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null)
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
        if (other.gameObject.GetComponent<Unit>() != null)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, distanceAttack);
    }

   
}
