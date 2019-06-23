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
        UpdateHUDRotation();
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
