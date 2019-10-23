using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public enum MODE { fight, build};
    private int indexMode = 0; //0 = build       1 = fight
    private int indexRow = 0; //index actuel de la page
    private int indexCol = 0;
    private int indexColMax = 4;
    private int indexRowMax = 2; //Nombre de pages max
    private int indexModeMax = 1; //Nombre de Mode max

    private GameObject hud;

    private GameObject modeGrid;
    private GameObject actionGrid;
    private GameObject buildGrid;


    private List<GameObject> modeGridMods;
    private List<GameObject> grids;

    void Start()
    {
        grids = new List<GameObject>();

        hud = transform.Find("Player_hud").gameObject;
        modeGrid = hud.transform.Find("ModeGrid").gameObject;

        actionGrid = hud.transform.Find("ActionGrid").gameObject;
        buildGrid = hud.transform.Find("BuildGrid").gameObject;
        grids.Add(actionGrid);
        grids.Add(buildGrid);

        modeGridMods = new List<GameObject>();

        for (int i = 0; i < modeGrid.transform.childCount; i++)
        {
            modeGridMods.Add(modeGrid.transform.GetChild(i).gameObject);
        }

        Debug.Log(indexRow);
        SetActiveGrid(indexRow);
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
            indexCol--;
            grids[indexRow].GetComponent<Grid>().SetSelected(indexCol);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            indexCol++;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeMode();
        }
    }

    private void ChangeMode()
    {
        indexMode++;
        if (indexMode > indexModeMax)
        {
            indexMode = 0;
        }

        SetActiveGrid(indexMode);
    }

    public void MoveUp()
    {
        indexRow++;
        if (indexRow > indexRowMax)
        {
            indexRow = 0;
        }
    }

    public void MoveDown()
    {
        indexRow--;
        if (indexRow < 0)
        {
            indexRow = indexRowMax;
        }
    }

    public void SetActiveGrid(int index)
    {
        for (int i = 0; i < grids.Count; i++)
        {
            if (i == indexRow)
            {
                grids[i].gameObject.SetActive(true);
            }
            else
            {
                grids[i].gameObject.SetActive(false);
            }
        }
    }

}
