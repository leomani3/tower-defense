using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cette classe, attachée à un objet possédant un collider, va se charger d'appliquer des dégats à la première cible qui entre dans le trigger avant de se détruire
/// </summary>
public class ColliderDamageOnce : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>() != null)
        {
            other.gameObject.GetComponent<Unit>().health -= damage;
            Destroy(gameObject);
            //TODO : peut être remplacer le destroy par des disable de certains script afin de pouvoir jouer un son avant le destroy de l'objet
        }
    }
}
