using UnityEngine;
using UnityEngine.AI;

public class Walker : Zombie
{
    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        CheckIfDie();

        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        else
        {
            Move();
        }
    }

}
