using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construct : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    public int indexItemToConstruct;
    public GameObject[] constructableItems;
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
    }

    // Update is called once per frame
    public void UpdatePos(Vector3 pos)
    {
        placeHolderItem.transform.position = new Vector3((int)pos.x+0.5f,(int)pos.y,(int)pos.z+0.5f);
        placeHolderItem.transform.rotation = Quaternion.identity;
    }

    public void SetItemToConstruct(int index)
    {
        indexItemToConstruct = index;

        //TODO : créerles mesh placeholder des batiments.
        //placeHolderItem.GetComponent<MeshFilter>().mesh = ...;
    }

    public void PlaceAndConstruct()
    {
        if(CanConstructItem())
        {
            GameObject go = Instantiate(constructableItems[indexItemToConstruct]);
            Vector3 buildingPos = placeHolderItem.transform.position;
            go.transform.position = new Vector3((int)buildingPos.x+0.5f,0.5f, (int)buildingPos.z+0.5f) ;
        }
    }

    public bool CanConstructItem()
    {
        BaseBuilding bb = constructableItems[indexItemToConstruct].GetComponent<BaseBuilding>();
        Vector3 buildingPos = placeHolderItem.transform.position;
        if (bb.costWood<=Base.WoodAmount && bb.costStone<=Base.StoneAmount && bb.costIron <= Base.IronAmount && bb.costCopper <= Base.CopperAmount)
        {
            if(levelGenerator.gridCellOccupied[(int)buildingPos.x+(int)buildingPos.z* levelGenerator.mapSize]==false)
            {
                return true;
            }
        }
        return false;
    }
}
