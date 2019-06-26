using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaDart : Ammunition
{
    public float stoppingPower;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Zombie")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * stoppingPower, ForceMode.Impulse);
            other.GetComponent<Zombie>().TakeDamage(damage);
        }
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
