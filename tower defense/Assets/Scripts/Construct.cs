using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construct : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    public GameObject itemToConstruct;
    public GameObject placeHolderItem;
    public LevelGenerator levelGenerator;
    // Start is called before the first frame update

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
    }

    private void Update()
    {
        UpdatePos(player.transform.position + player.transform.forward*2);
        if(Input.GetButtonDown(playerController.characterInputString+"A"))
        {
            PlaceAndConstruct();
        }
    }

    // Update is called once per frame
    public void UpdatePos(Vector3 pos)
    {
        placeHolderItem.transform.position = new Vector3((int)pos.x,(int)pos.y,(int)pos.z);
        placeHolderItem.transform.rotation = Quaternion.identity;
    }

    public void SetItemToConstruct(GameObject item)
    {
        itemToConstruct = item;
        BaseTurret bt = item.GetComponent<BaseTurret>();
        if (bt != null)
        {
            bt.enabled = false;
        }
        //TODO : créerles mesh placeholder des batiments.
        //placeHolderItem.GetComponent<MeshFilter>().mesh = ...;
    }

    public void PlaceAndConstruct()
    {
        if(CanConstructItem())
        {
            GameObject go = Instantiate(itemToConstruct);
            go.transform.position = placeHolderItem.transform.position;
        }
    }

    public bool CanConstructItem()
    {
        BaseBuilding bb = itemToConstruct.GetComponent<BaseBuilding>();
        if(bb.costWood<=Base.WoodAmount && bb.costStone<=Base.StoneAmount && bb.costIron <= Base.IronAmount && bb.costCopper <= Base.CopperAmount)
        {
            if(levelGenerator.gridCellOccupied[(int)itemToConstruct.transform.position.x+(int)itemToConstruct.transform.position.z* levelGenerator.mapSize]==false)
            {
                return true;
            }
        }
        return false;
    }
}
