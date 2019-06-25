using UnityEngine.UI;
using UnityEngine;

public class Player : Unit
{
    public Image modeImage;
    public Image energyBar;
    public float maxEnergy = 100f;
    public float attackEnergyCost = 20f;
    public float energyRegenSpeed = 30f;
    public Construct construct;
    
    private float currentEnergy;
    private int mode = 1; //1: action 2: construction

    // Start is called before the first frame update
    void Start()
    {
        modeImage.color = new Color(1, 0, 0, 1);
        construct.placeHolderItem.SetActive(false);
        currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        UpdateEnergy();

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            TakeDamage(1);
        }
    }

    public void ChangeMode()
    {
        if(mode == 1)
        {
            mode = 2;
            modeImage.color = new Color(0, 1, 1, 1);
            construct.placeHolderItem.SetActive(true);
        }
        else if (mode == 2)
        {
            mode = 1;
            modeImage.color = new Color(1, 0, 0, 1);
            construct.placeHolderItem.SetActive(false);
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
