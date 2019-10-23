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

    private void Start()
    {
        nbSlot = transform.childCount;
        slots = new GameObject[nbSlot];

        for (int i = 0; i < nbSlot; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
        }

        SetSelected(indexSlot);
    }

    public int GetIndexSlot()
    {
        return indexSlot;
    }


    public void MoveRight()
    {
        indexSlot++;
        if (indexSlot > nbSlot-1)
        {
            indexSlot = 0;
        }

        SetSelected(indexSlot) ;
    }

    public void MoveLeft()
    {
        indexSlot--;
        if (indexSlot < 0)
        {
            indexSlot = nbSlot;
        }
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
