using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public enum MODE { fight, build};
    private MODE currentMode;

    [SerializeField]
    private int indexMode = 0; //0 = fight       1 = build
    [SerializeField]
    private int indexModeMax;
    [SerializeField]
    private int indexSlot = 0;
    [SerializeField]
    private int indexSlotMax;
    [SerializeField]
    private int indexPage = 0;
    [SerializeField]
    private int indexPageMax;

    private GameObject ModeGrid;
    private GameObject FightGrid;
    private GameObject BuildGrid;

    private List<GameObject> actionGrids;

    void Start()
    {
        ModeGrid = transform.Find("Player_hud").Find("ModeGrid").gameObject;
        FightGrid = transform.Find("Player_hud").Find("FightGrid").gameObject;
        BuildGrid = transform.Find("Player_hud").Find("BuildGrid").gameObject;

        actionGrids = new List<GameObject>();
        actionGrids.Add(FightGrid);
        actionGrids.Add(BuildGrid);

        indexModeMax = ModeGrid.GetComponent<GridNavigator>().NbSlot;

        SetMode(0);
        SetActiveGrid();
        indexSlotMax = actionGrids[indexMode].GetComponent<GridNavigator>().NbSlot;
        indexPageMax = actionGrids[indexMode].GetComponent<GridNavigator>().NbPage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeMode();
        }

        Debug.Log(indexPage +" / " +indexPageMax);
        Debug.Log(indexSlot +" / "+indexSlotMax);
    }

    public void SetMode(int i)
    {
        if (i == 0)
            currentMode = MODE.build;
        else if (i == 1)
            currentMode = MODE.fight;
    }

    private void ChangeMode()
    {
        indexMode++;
        if (indexMode > indexModeMax - 1)
        {
            indexMode = 0;
        }
        SetMode(indexMode);

        ModeGrid.GetComponent<GridNavigator>().SetSelectedSlot(indexMode);
        SetActiveGrid();
    }


    public void MoveDown()
    {
        indexPage--;
        if (indexPage < 0)
        {
            indexPage = indexPageMax - 1;
        }
        actionGrids[indexMode].GetComponent<GridNavigator>().SetActivePage(indexPage);

        indexSlotMax = actionGrids[indexMode].GetComponent<GridNavigator>().NbSlot;
        if (indexSlot > indexSlotMax - 1)
        {
            indexSlot = indexSlotMax - 1;
        }

        actionGrids[indexMode].GetComponent<GridNavigator>().SetSelectedSlot(indexSlot);
    }
    
    public void MoveUp()
    {
        indexPage++;
        if (indexPage > indexPageMax - 1)
        {
            indexPage = 0;
        }

        actionGrids[indexMode].GetComponent<GridNavigator>().SetActivePage(indexPage);

        indexSlotMax = actionGrids[indexMode].GetComponent<GridNavigator>().NbSlot;
        if (indexSlot > indexSlotMax - 1)
        {
            indexSlot = indexSlotMax - 1;
        }
        actionGrids[indexMode].GetComponent<GridNavigator>().SetSelectedSlot(indexSlot);
    }

    public void MoveRight()
    {
        indexSlot++;
        if (indexSlot == indexSlotMax)
        {
            indexSlot = 0;
        }

        actionGrids[indexMode].GetComponent<GridNavigator>().SetSelectedSlot(indexSlot);
    }

    public void MoveLeft()
    {
        indexSlot--;
        if (indexSlot < 0)
        {
            indexSlot = indexSlotMax - 1;
        }

        actionGrids[indexMode].GetComponent<GridNavigator>().SetSelectedSlot(indexSlot);
    }

    public void SetActiveGrid()
    {
        for (int i = 0; i < actionGrids.Count; i++)
        {
            if (i == indexMode)
            {
                actionGrids[i].SetActive(true);
            }
            else
            {
                actionGrids[i].SetActive(false);
            }
        }

        if (indexSlot > actionGrids[indexMode].GetComponent<GridNavigator>().NbSlot-1) //Test pour éviter l'overflow quand on passe d'une grid sur laquelle on est à un indexSlot pour haut que l'indexSlotMax de la nouvelle grid
        {
            indexSlot = actionGrids[indexMode].GetComponent<GridNavigator>().NbSlot - 1;
        }
        actionGrids[indexMode].GetComponent<GridNavigator>().SetSelectedSlot(indexSlot);
        indexSlotMax = actionGrids[indexMode].GetComponent<GridNavigator>().NbSlot;
        indexPageMax = actionGrids[indexMode].GetComponent<GridNavigator>().NbPage;
    }

}
