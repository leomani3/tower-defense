using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaTurret : BaseTurret
{
    public GameObject ballista;
    public GameObject pedestal;
    public GameObject dart;

    public override void Attack()
    {
        cooldown = reloadTime;
        GameObject go = Instantiate(dart);
        go.transform.position = ballista.transform.position;
        go.transform.LookAt(target.transform.position);
        go.transform.Rotate(new Vector3(0, 180, 0));
        go.GetComponent<Ammunition>().direction = target.transform.position - ballista.transform.position;
        go.GetComponent<Ammunition>().damage = damage;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
        if (target != null)
        {
            ballista.transform.LookAt(target.transform.position);
            ballista.transform.Rotate(0, -90, 0);
            //pedestal.transform.LookAt(-target.transform.position);
        }
    }
}
