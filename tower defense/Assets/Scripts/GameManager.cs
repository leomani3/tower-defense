using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int CopperStartAmount;
    public static int IronStartAmount;
    public static int WoodStartAmount;
    public static int StoneSartAmount;

    public static int waveIndex = 0;

    public static int numberPlayer;

    private void Start()
    {
        //TDOO : Faire apparaître le bon nombre de HUD en fonction du nombre de joueur
    }

    public static void NextWave()
    {
        waveIndex++;
        //TODO : faire d'autres choses au passage à une nouvelle vage.
    }

}
