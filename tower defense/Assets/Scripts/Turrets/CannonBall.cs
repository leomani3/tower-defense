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
            foreach(GameObject go in targets)
            {
                go.GetComponent<Zombie>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
