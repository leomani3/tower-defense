using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTurret : BaseBuilding
{

    public GameObject target;
    public List<GameObject> zombiesInRange;
    public float cooldown;
    public float reloadTime;
    public int damage;


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
        List<int> targetsToRemove = new List<int>();
        for (int i = 0; i < zombiesInRange.Count; i++)
        {
            if(zombiesInRange[i] != null)
            {
                float currentDist = (zombiesInRange[i].transform.position - zombiesInRange[i].transform.position).sqrMagnitude;
                if(currentDist<minDist)
                {
                    target = zombiesInRange[i];
                    minDist = currentDist;
                }
            }
            else
            {
                targetsToRemove.Add(i);
            }
        }
        for(int i=targetsToRemove.Count;i>0;i--)
        {
            zombiesInRange.Remove(zombiesInRange[targetsToRemove[i-1]]);
        }
    }
}
