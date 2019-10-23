using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    private int indexMode = 0; //0 = build       1 = fight
    private int indexCol = 0; //index actuel de la case
    private int indexRow = 0; //index actuel de la page
    private int indexColMax = 5; //Nombre max de case max
    private int indexRowMax = 3; //Nombre de pages max
    private int indexModeMax = 2; //Nombre de Mode max

    private GameObject hud;

    private GameObject modeGrid;
    private GameObject actionGrid;
    private GameObject buildGrid;

    private GameObject selectMode;

    private List<GameObject> modeGridMods;

    void Start()
    {
        hud = transform.Find("Player1_hud").gameObject;
        modeGrid = hud.transform.Find("ModeGrid").gameObject;
        actionGrid = hud.transform.Find("ActionGrid").gameObject;
        buildGrid = hud.transform.Find("BuildGrid").gameObject;

        modeGridMods = new List<GameObject>();

        selectMode = hud.transform.Find("SelectMode").gameObject;

        for (int i = 0; i < modeGrid.transform.childCount; i++)
        {
            modeGridMods.Add(modeGrid.transform.GetChild(i).gameObject);
        }

        selectMode.transform.parent = modeGridMods[0].transform.parent;
        selectMode.transform.localPosition = modeGridMods[0].transform.localPosition;
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

    public void MoveLeft()
    {
        indexCol--;
        if (indexCol < 0)
        {
            indexCol = indexColMax;
        }
    }

    public void MoveRight()
    {
        indexCol++;
        if (indexCol > indexColMax)
        {
            indexCol = 0;
        }
    }

}
