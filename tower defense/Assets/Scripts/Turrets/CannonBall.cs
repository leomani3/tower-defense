using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Ammunition
{

    public List<GameObject> targets;
    public int damage;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        targets = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Zombie>()!=null)
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Zombie>() != null)
        {
            targets.Remove(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Zombie" || other.gameObject.tag=="Ground")
        {
            List<int> targetsToRemove = new List<int>();
            for(int i=0;i<targets.Count;i++)
            {
                if(targets[i]!=null)
                {
                    targets[i].GetComponent<Zombie>().TakeDamage(damage);
                }
                //else
                //{
                //    targetsToRemove.Add(i);
                //}
            }
            //foreach (int i in targetsToRemove)
            //{
            //    targets.Remove(targets[i]);
            //}
            Destroy(gameObject);
        }
    }
}
