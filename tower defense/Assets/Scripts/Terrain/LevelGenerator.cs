using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    public int mapSize;
    public int mountainNumber;
    public int lakeNumber;
    public int[] ressourcesAmounts;
    public Grid grid;
    public GameObject[] ressources;
    public GameObject[] obstacles;
    public GameObject terrain;
    public GameObject startArea;
    public GameObject[] Spawner;
    public int maxMountainSize;
    public int minMountainSize;
    public int maxLakeSize;
    public int minLakeSize;
    private bool[] gridCellOccupied;

    // Start is called before the first frame update
    void Start()
    {
        gridCellOccupied = new bool[mapSize * mapSize];
        for(int i=0;i< mapSize*mapSize;i++)
        {
            gridCellOccupied[i] = false;
        }
        CreateMap();

    }

    public void CreateMap()
    {
        CreateMountain();
        CreateWater();
        CreateTerrain();
        CreateRessources();

    }



    public void CreateMountain()
    {
        Vector2[] mountainPos = new Vector2[mountainNumber];
        int[] mountainSizes = new int[mountainNumber];
        for(int i=0;i<mountainNumber;i++)
        {
            int posX = UnityEngine.Random.Range(0, mapSize);
            int posZ = UnityEngine.Random.Range(0, mapSize); ;
            while (gridCellOccupied[posX + posZ * mapSize] == true)
            {
                posX = UnityEngine.Random.Range(0, mapSize);
                posZ = UnityEngine.Random.Range(0, mapSize);
            }
            
            mountainPos[i] = new Vector2(posX, posZ);

            int mountainSize = UnityEngine.Random.Range(minMountainSize, maxMountainSize);
            mountainSizes[i] = mountainSize;
            for(int j=-mountainSize;j<=mountainSize;j++)
            {
                for(int k=-mountainSize;k<=mountainSize;k++)
                {
                    if(posX + k + mapSize * (posZ + j)>=0 && posX + k + mapSize * (posZ + j) <mapSize*mapSize && gridCellOccupied[posX + k + mapSize * (posZ + j)] != true)
                    {
                        GameObject go = Instantiate(obstacles[0]);
                        go.transform.position = new Vector3(posX+k+0.5f, 0.5f, posZ+j+0.5f);
                        go.transform.localScale =new Vector3(1,1+mountainSize-Math.Max(Math.Abs(j),Math.Abs(k)),1);
                        gridCellOccupied[posX+k + mapSize * (posZ+j)] = true;
                    }
                }
            }
        }
    }

    private void CreateWater()
    {
        Vector2[] lakePos = new Vector2[lakeNumber];
        int[] LakeSizes = new int[lakeNumber];
        for (int i = 0; i < lakeNumber; i++)
        {
            int posX = UnityEngine.Random.Range(0, mapSize);
            int posZ = UnityEngine.Random.Range(0, mapSize); ;
            while (gridCellOccupied[posX + posZ * mapSize] == true)
            {
                posX = UnityEngine.Random.Range(0, mapSize);
                posZ = UnityEngine.Random.Range(0, mapSize);
            }

            lakePos[i] = new Vector2(posX, posZ);

            int lakeSize = UnityEngine.Random.Range(minLakeSize, maxLakeSize);
            LakeSizes[i] = lakeSize;
            for (int j = -lakeSize; j < lakeSize; j++)
            {
                for (int k = -lakeSize; k < lakeSize; k++)
                {
                    if (posX + k + mapSize * (posZ + j) >= 0 && posX + k + mapSize * (posZ + j) < mapSize * mapSize && gridCellOccupied[posX + k + mapSize * (posZ + j)] != true)
                    {
                        GameObject go = Instantiate(obstacles[1]);
                        go.transform.position = new Vector3(posX + k + 0.5f, -0.5f, posZ + j + 0.5f);
                        gridCellOccupied[posX + k + mapSize * (posZ + j)] = true;
                    }
                }
            }
        }
    }

    private void CreateRessources()
    {
        for(int i = 0;i<ressources.Length;i++)
        {
            for(int j =0;j<ressourcesAmounts[i];j++)
            {
                int posX = UnityEngine.Random.Range(0, mapSize);
                int posZ = UnityEngine.Random.Range(0, mapSize); ;
                while (gridCellOccupied[posX + posZ * mapSize] == true)
                {
                    posX = UnityEngine.Random.Range(0, mapSize);
                    posZ = UnityEngine.Random.Range(0, mapSize);
                }

                GameObject go = Instantiate(ressources[i]);
                go.transform.position = new Vector3(posX + 0.5f, 0.5f, posZ  + 0.5f);
                gridCellOccupied[posX + mapSize * posZ] = true;
            }

        }
    }

    private void CreateTerrain()
    {
        for(int i =0;i<mapSize;i++)
        {
            for(int j=0;j<mapSize;j++)
            {
                if(gridCellOccupied[i*mapSize+j]==false)
                {
                    GameObject go = Instantiate(terrain);
                    go.transform.position = new Vector3(j + 0.5f, -0.5f, i + 0.5f);
                    //gridCellOccupied[j + mapSize * i] = true;
                }
            }
        }
    }
}
