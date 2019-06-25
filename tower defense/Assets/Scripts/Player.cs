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

    //HUD
    private Canvas hud;
    private Image energyBar;
    private GridNavigator modeGrid;
    private GameObject[] actionGrids;

    // Start is called before the first frame update
    void Start()
    {
        construct.placeHolderItem.SetActive(false);
        currentEnergy = maxEnergy;

        //va chercher automatiquement le bon hud par rapport au player number;
        hud = GameObject.Find("Player" + playerNumber + "_hud").GetComponent<Canvas>();
        healthBar = hud.transform.Find("HealthBar").GetComponent<Image>();
        energyBar = hud.transform.Find("EnergyBar").GetComponent<Image>();
        modeGrid = hud.transform.Find("ModeGrid").Find("ModeGrid").GetComponent<GridNavigator>();
        actionGrids = new GameObject[hud.transform.Find("ActionGrids").childCount];
        for(int i=0; i<actionGrids.Length; i++)
        {
            actionGrids[i] = hud.transform.Find("ActionGrids").GetChild(i).gameObject;
        }

        GridSetActive(0, true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDie();

        UpdateEnergy();

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            TakeDamage(1);
        }
    }

    void GridSetActive(int number, bool active)
    {
        actionGrids[number].SetActive(active);
        if (active)
        {
            activeGrid = actionGrids[number].GetComponent<GridNavigator>();
            activeGrid.SetSelected(activeGrid.currentIndexGrid, false);
            activeGrid.SetActivePage(0);
        }
    }

    public void ChangeMode()
    {
        modeGrid.ForwardGrid();
        mode = modeGrid.currentIndexGrid;
        if(mode == 0)
        {
            GridSetActive(0, true);
            GridSetActive(1, false);
            construct.placeHolderItem.SetActive(false);
        }
        else
        {
            GridSetActive(0, false);
            GridSetActive(1, true);
            construct.placeHolderItem.SetActive(true);
        }
    }

    /// <summary>
    /// Permet de se déplacer vers la droite dans la grille active (action ou construction)
    /// </summary>
    public void RightActiveGrid()
    {
        activeGrid.ForwardGrid();
    }

    public void LeftActiveGrid()
    {
        activeGrid.BackwardGrid();
    }

    public void NextPageActiveGrid()
    {
        activeGrid.NextPage();
    }

    public void PreviousPageActiveGrid()
    {
        activeGrid.PreviousPage();
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

    public int Mode
    {
        get { return mode; }
    }

    void UpdateEnergy()
    {
        if(currentEnergy<maxEnergy)
        {
            currentEnergy += Time.deltaTime * energyRegenSpeed;
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
            energyBar.fillAmount = currentEnergy / maxEnergy;
        }
    }
}
