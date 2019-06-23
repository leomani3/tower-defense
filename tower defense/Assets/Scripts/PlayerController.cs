using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;


    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //SOURIS : LE PLAYER REGARDE EN DIRECTION DE LA SOURIS
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        //---------------------------------------------------


        //MANETTE : LE PLAYER REGARDE EN DIRECTION DE LA SOURIS
        //---------------------------------------------------

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveRight = Vector3.right * hAxis * speed * Time.deltaTime;
        Vector3 moveUp = Vector3.forward * vAxis * speed * Time.deltaTime;

        rb.MovePosition(transform.position + moveRight + moveUp);
    }
}
