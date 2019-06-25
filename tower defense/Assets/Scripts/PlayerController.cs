using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public string characterInputString;

    private Rigidbody rb;
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerScript = GetComponent<Player>();
        characterInputString = "character " + playerScript.playerNumber + " ";
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------LOOKAT--------------------
        //clavier / souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        //manette
        float horizontalAim = Input.GetAxisRaw(characterInputString + "aim horizontal");
        float verticalAim = Input.GetAxisRaw(characterInputString + "aim vertical");

        transform.LookAt(new Vector3(transform.position.x + verticalAim, transform.position.y, transform.position.z + horizontalAim));


        //--------------------MOUVEMENT--------------------
        //manette
        float vAxis = Input.GetAxisRaw(characterInputString + "move horizontal");
        float hAxis = Input.GetAxisRaw(characterInputString + "move vertical");

        Vector3 moveRightController = -Vector3.forward * hAxis * speed * Time.deltaTime;
        Vector3 moveUpController = Vector3.right * vAxis * speed * Time.deltaTime;

        //clavier / souris
        float veAxis = Input.GetAxisRaw("Horizontal");
        float hoAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveRightKeyboard =Vector3.forward * hoAxis * speed * Time.deltaTime;
        Vector3 moveUpKeyboard = Vector3.right * veAxis * speed * Time.deltaTime;

        //On appelle une seule fois MovePosition pour les deux modes de controles car elle ne peut être appeler qu'une seule fois. Si on l'appele plusieurs fois, seule la dernière est prise en compte
        rb.MovePosition(transform.position + moveRightController + moveRightKeyboard + moveUpController + moveUpKeyboard);

        //--------------------BOUTON CHANGE MODE--------------------
        //Manette
        //clavier / souris
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerScript.ChangeMode();
        }

        //--------------------BOUTON NAVIGUER DROITE DANS LA GRID ACTION --------------------
        //Manette
        //clavier / souris
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerScript.RightActiveGrid();
        }

        //--------------------BOUTON NAVIGUER GAUCHE DANS LA GRID ACTION --------------------
        //Manette
        //clavier / souris
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerScript.LeftActiveGrid();
        }

        //--------------------BOUTON NAVIGUER PAGE SUIVANTE DANS LA GRID ACTION --------------------
        //Manette
        //clavier / souris
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerScript.NextPageActiveGrid();
        }

        //--------------------BOUTON NAVIGUER PAGE PRECEDENTE DANS LA GRID ACTION --------------------
        //Manette
        //clavier / souris
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerScript.PreviousPageActiveGrid();
        }


        //--------------------BOUTON ACTION--------------------
        //Manette
        if (Input.GetButtonDown(characterInputString + "A"))
        {
            if (playerScript.Mode == 0) //mode action
            {
                playerScript.Attack();
            }
            else if (playerScript.Mode == 1) //mode construction
            {
                playerScript.Construct();
            }
        }
        //clavier / souris
        if (Input.GetMouseButtonDown(0)){
            if(playerScript.Mode == 0) //mode action
            {
                playerScript.Attack();
            }
            else if(playerScript.Mode == 1){ //mode construction
                playerScript.Construct();
            }
        }
    }
}
