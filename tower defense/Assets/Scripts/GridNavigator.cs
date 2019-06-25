using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridNavigator : MonoBehaviour
{
    public int currentIndexGrid = 0;
    public int currentIndexPage = 0;

    private int gridCount;
    private int pageCount;
    private string[] baseImageNames;
    private TextMeshProUGUI textNombrePage;
    // Start is called before the first frame update
    void Start()
    {
        pageCount = transform.childCount;
        textNombrePage = transform.parent.parent.Find("TextNombrePage").GetComponent<TextMeshProUGUI>();
        SetActivePage(0);
        currentIndexPage = 0;
    }

    public void RefreshPageCount()
    {
        pageCount = transform.childCount;
    }


    /// <summary>
    /// Cette fonction permet de changer la page active d'une grille. Elle désactive l'ancienne et active la nouvelle.
    /// </summary>
    public void SetActivePage(int number)
    {
        currentIndexPage = number;

        RefreshPageCount();
        textNombrePage.text = currentIndexPage+1 + " / " + pageCount;

        transform.GetChild(currentIndexPage).gameObject.SetActive(true);
        gridCount = transform.GetChild(currentIndexPage).childCount;
        baseImageNames = new string[gridCount];
        for (int i = 0; i < gridCount; i++)
        {
            baseImageNames[i] = transform.GetChild(currentIndexPage).GetChild(i).GetComponent<Image>().sprite.name;
        }

        SetSelected(0, true);
        currentIndexGrid = 0;
    }

    public void NextPage()
    {
        if (pageCount > 1)
        {
            SetSelected(currentIndexGrid, false);
            transform.GetChild(currentIndexPage).gameObject.SetActive(false);

            currentIndexPage++;
            if (currentIndexPage == pageCount)
            {
                currentIndexPage = 0;
            }
            SetActivePage(currentIndexPage);
        }
    }

    public void PreviousPage()
    {
        if (pageCount > 1)
        {
            SetSelected(currentIndexGrid, false);
            transform.GetChild(currentIndexPage).gameObject.SetActive(false);

            currentIndexPage--;
            if (currentIndexPage < 0)
            {
                currentIndexPage = pageCount-1;
            }
            SetActivePage(currentIndexPage);
        }
    }

    public void ForwardGrid()
    {
        //On déselectionne l'ancien
        SetSelected(currentIndexGrid, false);

        currentIndexGrid++;
        if (currentIndexGrid == gridCount)
        {
            currentIndexGrid = 0;
        }
        SetSelected(currentIndexGrid, true);
    }

    public void BackwardGrid()
    {
        //On déselectionne l'ancien
        SetSelected(currentIndexGrid, false);

        currentIndexGrid--;
        if (currentIndexGrid < 0)
        {
            currentIndexGrid = gridCount-1;
        }
        SetSelected(currentIndexGrid, true);
    }

    /// <summary>
    /// Cette fonction permet de changer la case qui est selectionnée
    /// </summary>
    /// <param name="index"></param>
    /// <param name="selected"></param>
    public void SetSelected(int index, bool selected)
    {
        if (selected)
        {
            transform.GetChild(currentIndexPage).GetChild(index).GetComponent<Image>().sprite = Resources.Load<Sprite>(baseImageNames[index]+"Selected");
        }
        else
        {
            transform.GetChild(currentIndexPage).GetChild(index).GetComponent<Image>().sprite = Resources.Load<Sprite>(baseImageNames[index]);
        }
    }
}
