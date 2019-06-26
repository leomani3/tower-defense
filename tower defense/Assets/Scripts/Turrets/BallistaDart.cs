using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaDart : Ammunition
{
    public float stoppingPower;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Zombie" )
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * stoppingPower, ForceMode.Impulse);
            other.gameObject.GetComponent<Zombie>().TakeDamage(damage);
        }
        if(other.gameObject.tag == "Ground" )
        {
            Destroy(gameObject);
        }
    }
}
