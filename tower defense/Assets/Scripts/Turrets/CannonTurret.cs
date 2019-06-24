using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurret : BaseTurret
{
    public GameObject cannon;
    public GameObject pedestal;
    public GameObject cannonball;

    public override void Attack()
    {
        cooldown = reloadTime;
        GameObject go = Instantiate(cannonball); 
        go.transform.position = cannon.transform.position-cannon.transform.forward;
        go.transform.LookAt(target.transform.position);
        go.GetComponent<Ammunition>().direction = target.transform.position - cannon.transform.position;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
        if(target != null)
        {
            cannon.transform.LookAt(-target.transform.position);
            pedestal.transform.LookAt(-target.transform.position);
        }
    }
}
