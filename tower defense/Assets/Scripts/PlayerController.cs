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
        float hRightJoystick = Input.GetAxisRaw("HorizontalRightJoystick");
        float vRightJoystick = Input.GetAxisRaw("VerticalRightJoystick");

        Vector3 horizontal = new Vector3(0, 0, hRightJoystick);
        Vector3 vertical = new Vector3(vRightJoystick, 0, 0);
        transform.LookAt(transform.position + horizontal + vertical);
        //---------------------------------------------------

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveRight = Vector3.forward * hAxis * speed * Time.deltaTime;
        Vector3 moveUp = -Vector3.right * vAxis * speed * Time.deltaTime;

        rb.MovePosition(transform.position + moveRight + moveUp);
    }
}
