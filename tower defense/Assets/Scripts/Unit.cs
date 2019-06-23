using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;

    /// <summary>
    /// regarde si la vie du zombie est a zéro. si oui, destroy le gameobject
    /// </summary>
    protected void CheckIfDie()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //TODO : il faudra surement remplacer Destroy pas Disable certaisn script, jouer un son, puis destroy.
        }
    }
}
