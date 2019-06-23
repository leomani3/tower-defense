using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cette classe, attachée à un objet possédant un collider en trigger, va se charger d'appliquer des dégats au fil du temps à toutes les cibles dans son trigger
/// </summary>
public class ColliderDOTNearest : MonoBehaviour
{
    public int damage = 1;
    public float timeBetweenDamage = 1f;

    private float timeCount = 0;

    private void Update()
    {
        timeCount -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null && timeCount <= 0)
        {
            other.gameObject.GetComponent<Unit>().health -= damage;
            timeCount = timeBetweenDamage;
        }
    }
}
