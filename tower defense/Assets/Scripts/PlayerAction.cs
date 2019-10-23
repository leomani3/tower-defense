using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public enum MODE { fight, build};
    private MODE currentMode;

    private int indexMode = 0; //0 = build       1 = fight
    private int indexModeMax;

    private GameObject ModeGrid;

    void Start()
    {
        ModeGrid = transform.Find("Player_hud").Find("ModeGrid").gameObject;
        indexModeMax = ModeGrid.GetComponent<GridNavigator>().NbSlot;

        SetMode(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeMode();
        }
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
    }

    public void MoveUp()
    {
    }

    public void MoveDown()
    {
    }

    public void MoveRight()
    {

    }

    public void MoveLeft()
    {

    }

}
