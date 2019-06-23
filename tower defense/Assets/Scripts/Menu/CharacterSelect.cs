using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{

    public GameObject panelJoin;
    public GameObject panelCharSelect;
    public GameObject panelBackGround;
    public Image panelBackGroundImage;
    public int playerNumber;

    public GameObject CharSelectTerrain;
    public SpawnCharacter charSpawn;

    public int characterIndex;
    public Image characterImage;

    public Image loadBar;
    public float fillAmount;

    public string characterInputString;
    public CharacterSelectManager CSM;

    public Button buttonLeft;
    public Button buttonRight;


    public Step step;
    // Start is called before the first frame update
    void Start()
    {
        panelJoin.SetActive(true);
        panelCharSelect.SetActive(false);
        panelBackGround.SetActive(true);
        panelBackGround.GetComponent<Image>().color = new Vector4(0, 0, 255, 255);
        panelBackGroundImage = panelBackGround.GetComponent<Image>();
        panelBackGroundImage.sprite = CSM.characterImageList[0];
        characterInputString = "character " + playerNumber + " ";
    }

    // Update is called once per frame
    void Update()
    {
        if(step==Step.Join)
        {
            if (Input.GetButtonDown(characterInputString + "A"))
            {
                panelJoin.SetActive(false);
                panelCharSelect.SetActive(true);
                step = Step.CharSelect;
                CSM.ChangePlayerStatus(playerNumber, CharacterSelectManager.Step.CharSelect);
                charSpawn.character = CSM.characterList[characterIndex];
            }
        }



        else if( step == Step.CharSelect)
        {

            if(Input.GetAxisRaw(characterInputString + "move horizontal")<-0.15)
            {
                buttonLeft.onClick.Invoke();
            }
            if (Input.GetAxisRaw(characterInputString + "move horizontal") > 0.15)
            {
                buttonRight.onClick.Invoke();
            }

            if (Input.GetButtonDown(characterInputString + "A"))
            {
                panelCharSelect.SetActive(false);
                panelBackGround.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
                step = Step.Play;
                CSM.ChangePlayerStatus(playerNumber, CharacterSelectManager.Step.Play);
                CharSelectTerrain.SetActive(true);
                charSpawn.CharacterSpawn(charSpawn.gameObject.transform.position);
            }
            if (Input.GetButtonDown(characterInputString + "B"))
            {
                panelJoin.SetActive(true);
                panelCharSelect.SetActive(false);
                panelBackGround.GetComponent<Image>().color = new Vector4(0, 0, 255, 255);
                step = Step.Join;
                CSM.ChangePlayerStatus(playerNumber, CharacterSelectManager.Step.Join);
            }
        }



        else if( step == Step.Play)
        {
            if (Input.GetButtonDown(characterInputString + "B"))
            {
                panelCharSelect.SetActive(true);
                panelBackGround.GetComponent<Image>().color = new Vector4(0, 255, 0, 0);
                step = Step.CharSelect;
                CSM.ChangePlayerStatus(playerNumber, CharacterSelectManager.Step.CharSelect);
                CharSelectTerrain.SetActive(false);
                charSpawn.DespawnCharacter();
                charSpawn.character = CSM.characterList[characterIndex];
                loadBar.fillAmount = 0;

            }
            if (Input.GetButton(characterInputString + "A") && CSM.readyToStart)
            {
                loadBar.fillAmount+=fillAmount;
                if(loadBar.fillAmount>=1)
                {
                    loadBar.color = new Vector4(0, 255, 0, 255);
                    CSM.PlayerReady(true);
                }
            }
            else if(!Input.GetButton(characterInputString + "A") && CSM.readyToStart)
            {
                if (loadBar.fillAmount >= 1)
                {
                    loadBar.color = new Vector4(255, 0, 0, 255);
                    CSM.PlayerReady(false);
                }
                loadBar.fillAmount-=fillAmount;
            }
        }    
    }



    public enum Step
    {
        Join,
        CharSelect,
        Play,
    }
}
