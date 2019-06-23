using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Unit
{
    private static int copperAmount;
    private static int ironAmount;
    private static int woodAmount;
    private static int stoneAmount;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;

        //On va chercher les settings du GameManager pour savoir le nombre de ressources de départ
        copperAmount = GameManager.CopperStartAmount;
        ironAmount = GameManager.IronStartAmount;
        woodAmount = GameManager.WoodStartAmount;
        stoneAmount = GameManager.StoneSartAmount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDie();

        Debug.Log("Iron : " + ironAmount);
        Debug.Log("Copper : " + copperAmount);
        Debug.Log("Wood : " + woodAmount);
        Debug.Log("Stone : " + stoneAmount);
    }

    //------------- METHODS -------------

    public static void ConsumeIron(int value)
    {
        ironAmount -= value;
    }

    public static void ConsumeCopper(int value)
    {
        copperAmount -= value;
    }

    public static void ConsumeWood(int value)
    {
        woodAmount -= value;
    }

    public static void ConsumeStone(int value)
    {
        stoneAmount -= value;
    }

    public static void addIron(int value)
    {
        ironAmount += value;
    }

    public static void addCopper(int value)
    {
        copperAmount += value;
    }

    public static void addWood(int value)
    {
        woodAmount += value;
    }

    public static void addStone(int value)
    {
        stoneAmount += value;
    }

    //Override de la méthode de Unit car la mort de la base gère la fin de la partie
    private new void CheckIfDie()
    {
        if (health <= 0)
        {
            //TODO : Mettre ici le code pour la fin de partie
        }
    }

    //------------- GETTERS / SETTERS -------------

    public int IronAmount
    {
        get{return ironAmount;}
        set { ironAmount = value;}
    }

    public int CopperAmount
    {
        get { return copperAmount; }
        set { copperAmount = value; }
    }

    public int WoodAmount
    {
        get { return woodAmount; }
        set { woodAmount = value; }
    }

    public int StoneAmount
    {
        get { return stoneAmount; }
        set { stoneAmount = value; }
    }
}
