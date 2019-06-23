using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cette classe, attachée à un objet possédant un collider en trigger, va se charger d'appliquer des dégats au fil du temps à toutes les cibles dans son trigger
/// </summary>
public class ColliderDOTAOE : MonoBehaviour
{
    public int damage = 1;
    public float timeBetweenDamage = 1f;

    private float timeCount = 0;
    private List<GameObject> targets;

    private void Start()
    {
        targets = new List<GameObject>();
    }

    private void Update()
    {
        timeCount -= Time.deltaTime;
        if(timeCount <= 0)
        {
            foreach (GameObject go in targets)
            {
                go.GetComponent<Unit>().health -= damage;
                timeCount = timeBetweenDamage;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>())
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
    }
}
