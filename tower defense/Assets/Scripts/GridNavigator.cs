using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridNavigator : MonoBehaviour
{
    private int nbSlot;
    private int nbPage;

    private List<GameObject> slots;
    private List<GameObject> pages;

    public int NbSlot
    {
        get { return nbSlot; }
    }

    public int NbPage
    {
        get { return nbPage; }
    }

    private void Start()
    {
        nbSlot = 0;

        //initialisation des lists
        slots = new List<GameObject>();
        pages = new List<GameObject>();

        //comptage de toutes les pages
        nbPage = transform.childCount;
        for (int i = 0; i < nbPage; i++)
        {
            pages.Add(transform.GetChild(i).gameObject);
        }

        SetActivePage(0);
        SetSelectedSlot(0);
    }


    public void SetActivePage(int index)
    {
        //affichage
        for (int i = 0; i < pages.Count; i++)
        {
            if (i == index)
            {
                pages[i].gameObject.SetActive(true);
            }
            else
            {
                pages[i].gameObject.SetActive(false);
            }
        }

        //mise à jour des variables
        nbSlot = pages[index].transform.childCount;
        Debug.Log("La page : " + index + " a " + pages[index].transform.childCount);
        for (int i = 0; i < nbSlot; i++)
        {
            slots.Add(pages[index].transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Gère la sélection du currentSlot au niveua visuel
    /// </summary>
    public void SetSelectedSlot(int ind)
    {
        for (int i = 0; i < nbSlot; i++)
        {
            if (i == ind)
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
