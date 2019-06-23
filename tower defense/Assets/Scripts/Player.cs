using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDie();
        UpdateHUDRotation();

        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(1);
        }
    }
}
