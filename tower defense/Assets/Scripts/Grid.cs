using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int nbSlot;
    private GameObject[] slots;
    private GameObject selector;

    private int indexSlot=0;


    public void SetActivePage(int index)
    {

    }

    /// <summary>
    /// Gère la sélection du currentSlot au niveua visuel
    /// </summary>
    public void SetSelected(int ind)
    {
        indexSlot = ind;
        for (int i = 0; i < nbSlot; i++)
        {
            if(i == ind)
            {
                slots[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                slots[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
