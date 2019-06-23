using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{
    public CharacterSelectManager CSM;
    public CharacterSelect CharSelect;
    public SpawnCharacter SpawnChar;

    public int charListSize;

    public int i;

    private void Start()
    {
        charListSize = CSM.characterList.Length;
    }

    public void CharacterSwap()
    {
        CharSelect.characterIndex = (CharSelect.characterIndex + i) % charListSize;
        if (CharSelect.characterIndex < 0)
        {
            CharSelect.characterIndex += charListSize;
        }
        SpawnChar.character = CSM.characterList[CharSelect.characterIndex];
        CharSelect.characterImage.color = CSM.characterList[CharSelect.characterIndex].GetComponent<MeshRenderer>().sharedMaterial.color;
        CharSelect.panelBackGroundImage.sprite = CSM.characterImageList[CharSelect.characterIndex];
    }
}
