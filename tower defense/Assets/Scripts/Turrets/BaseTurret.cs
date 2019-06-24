using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTurret : BaseBuilding
{

    public GameObject target;
    public List<GameObject> zombiesInRange;
    public float cooldown;
    public float reloadTime;


    // Start is called before the first frame update
    void Start()
    {
        zombiesInRange = new List<GameObject>();
        target = null;
    }

    // Update is called once per frame
    protected new void  Update()
    {
        base.Update();
        if (cooldown <= 0 && target!=null)
        {
            Attack();
        }
        cooldown -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Zombie>()!=null)
        {
            if(target==null)
            {
                target = other.gameObject;
            }
            zombiesInRange.Add(other.gameObject);      
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Zombie>() != null)
        {
            if (other.gameObject == target)
            {
                ChooseTarget();
            }
            zombiesInRange.Remove(other.gameObject);
        }
    }

    abstract public void Attack();

    public void ChooseTarget()
    {
        float minDist = 9999999.0f;
        target = null;
        foreach(GameObject go in zombiesInRange)
        {
            float currentDist = (go.transform.position - go.transform.position).sqrMagnitude;
            if(currentDist<minDist)
            {
                target = go;
                minDist = currentDist;
            }
        }
    }
}
