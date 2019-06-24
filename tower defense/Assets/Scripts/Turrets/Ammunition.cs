using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    public float speed;
    public float weight;
    public Vector3 direction;
    Rigidbody rb;

    // Start is called before the first frame update
    protected void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.mass = weight;
        rb.velocity = direction.normalized * speed;
    }

    public void SetVelocity(Vector3 v)
    {
        rb.velocity = v.normalized * speed;

    }
}
