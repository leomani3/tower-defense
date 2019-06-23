using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public int playerNumber;
    public string characterInputString;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterInputString = "character " + playerNumber + " ";
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

        float horizontalAim = Input.GetAxisRaw(characterInputString + "aim horizontal");
        float verticalAim = Input.GetAxisRaw(characterInputString + "aim vertical");

        transform.LookAt(new Vector3(transform.position.x+verticalAim, transform.position.y, transform.position.z+horizontalAim));

        float hAxis = Input.GetAxisRaw(characterInputString + "move horizontal");
        float vAxis = Input.GetAxisRaw(characterInputString + "move vertical");

        Vector3 moveRight = Vector3.forward * hAxis * speed * Time.deltaTime;
        Vector3 moveUp = Vector3.right * vAxis * speed * Time.deltaTime;

        rb.MovePosition(transform.position + moveRight + moveUp);

        //---------------------------------------------------

        //float hoAxis = Input.GetAxisRaw("Horizontal");
        //float veAxis = Input.GetAxisRaw("Vertical");

        //moveRight = Vector3.forward * hoAxis * speed * Time.deltaTime;
        //moveUp = -Vector3.right * veAxis * speed * Time.deltaTime;

        //rb.MovePosition(transform.position + moveRight + moveUp);
    }
}
