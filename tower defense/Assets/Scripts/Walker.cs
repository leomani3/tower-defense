using UnityEngine;
using UnityEngine.AI;

public class Walker : Zombie
{
    private void Start()
    {
        Setup();
        timeBetweenAttacks = 1;
    }

    private void Update()
    {
        CheckIfDie();

        timeCount -= Time.deltaTime;

        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
            if (CheckDistanceAttack() && timeCount <= 0)
            {
                Debug.Log("ATTACK");
                target.GetComponent<Unit>().health--;
                timeCount = timeBetweenAttacks;
            }
        }
        else
        {
            Move();
        }
    }

}
