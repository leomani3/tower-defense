using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnCharacter : MonoBehaviour
{

    public GameObject character;
    
    public void SetCharacter(GameObject cha)
    {
        character = cha;
    }

    public void CharacterSpawn(Vector3 pos)
    {
        GameObject go = Instantiate(character, gameObject.transform);
        go.transform.position = pos;
        character = go;
        if(SceneManager.GetActiveScene().name == "CharacterSelection")
        {
            //character.GetComponent<CharacterRessources>().enabled = false;
        }
    }

    public void DespawnCharacter()
    {
        Destroy(character);
    }
}
