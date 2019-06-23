using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{

    public CharacterSelect[] characterSelects;
    public  Step[] playerStates;
    public GameObject[] characterList;
    public Sprite[] characterImageList;

    public int[]characterIndexes;

    public  bool readyToStart;
    public  int requiredPlayers;
    public  int readyPlayers;
    public int neededPlayerAmountToStart;

    public  string sceneToLoad;

    private void Start()
    {
        readyToStart = false;
    }

    public  void ChangePlayerStatus(int playerNumber, Step step)
    {
        playerNumber--;
        playerStates[playerNumber] = step;
        int cptr = 0;
        bool canStart = true;
        foreach (Step s in playerStates)
        {
            if (s == Step.Play)
            {
                cptr++;
            }
            if (s == Step.CharSelect)
            {
                canStart = false;
            }
        }
        if (cptr >= neededPlayerAmountToStart && canStart)
        {
            SetReadyToPlay(true);
            requiredPlayers = cptr;
        }
        else
        {
            SetReadyToPlay(false);
        }
    }

    public  void SetReadyToPlay(bool b)
    {
        readyToStart = b;

    }

    public  void PlayerReady(bool b)
    {
        if(b)
        {
            readyPlayers++;
        }
        else
        {
            readyPlayers--;
        }
        if(readyPlayers==requiredPlayers)
        { 

            LoadScene();
        }
    }

    private void LoadScene()
    {

        SceneManager.LoadScene(sceneToLoad);
    }

    public enum Step
    {
        Join,
        CharSelect,
        Play,
    }

}
