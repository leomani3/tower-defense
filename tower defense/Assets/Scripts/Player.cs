using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class Player : Unit
{
    public float maxEnergy = 100f;
    public float attackEnergyCost = 20f;
    public float energyRegenSpeed = 30f;
    public int playerNumber;
    public Construct construct;
    
    private float currentEnergy;
    private int mode = 0; //0: action 1: construction
    private GridNavigator activeGrid;


    // Start is called before the first frame update
    void Start()
    {
        construct.placeHolderItem.SetActive(false);
        currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDie();

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            TakeDamage(1);
        }
    }



    public void Attack()
    {
        if(currentEnergy > attackEnergyCost)
        {
            Debug.Log("ATTACK");
            currentEnergy -= attackEnergyCost;
        }
        else
        {
            Debug.Log("PAS ASSEZ D'ÉNERGIE POUR ATTAQUER");
        }
    }

    public void Construct()
    {
        if (currentEnergy == maxEnergy)
        {
            Debug.Log("CONSTRUCT");
            construct.PlaceAndConstruct();
            currentEnergy -= maxEnergy;
        }
        else
        {
            Debug.Log("PAS ASSEZ D'ÉNERGIE POUR CONSTRUIRE");
        }
    }
}
