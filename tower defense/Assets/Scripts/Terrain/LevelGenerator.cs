using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{

    public int mapSize;

    // paramètres des obstacles inamovibles sur la carte
    public int mountainNumber;
    public int lakeNumber;
    public GameObject[] obstacles;
    public int maxMountainSize;
    public int minMountainSize;
    public int maxLakeSize;
    public int minLakeSize;

    public GameObject terrain;

    // paramètres de la base
    // taille de la base (nb de tiles dans un sens en plus du centre. ex : batiment de la largeur 3 -> baseSize = 1, batiment de la largeur 7 -> baseSize = 3) 
    public int baseSize;
    public int offsetWallBase;
    public GameObject playerBase;

    public GameObject[] Spawner;

    // paramètres des ressources
    public GameObject[] ressources;
    public int[] ressourcesAmounts;
    public int[] minRessourcesPackSize;
    public float ressourcePackDensity;

    public GameObject zombieSpawner;
    public int zombieSpawnerAmount;
    int zombieSpawnerOffset;




    private bool[] gridCellOccupied;

    // Start is called before the first frame update
    void Start()
    {
        gridCellOccupied = new bool[mapSize * mapSize];
        zombieSpawnerOffset = zombieSpawner.GetComponent<Spawner>().maxSpawnPositionOffset;
        for (int i=0;i< mapSize*mapSize;i++)
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
        CreateBase();
        CreateRessources();
        CreateZombieSpawners();
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
                }
            }
        }
    }

    private void CreateRessources()
    {
        for (int i = 0; i < ressources.Length; i++)
        {
            for (int j = 0; j < ressourcesAmounts[i]; j++)
            {
                //int posX = UnityEngine.Random.Range(0, mapSize);
                //int posZ = UnityEngine.Random.Range(0, mapSize); ;
                //while (gridCellOccupied[posX + posZ * mapSize] == true)
                //{
                //    posX = UnityEngine.Random.Range(0, mapSize);
                //    posZ = UnityEngine.Random.Range(0, mapSize);
                //}

                //GameObject go = Instantiate(ressources[i]);
                //go.transform.position = new Vector3(posX + 0.5f, 0.5f, posZ + 0.5f);
                //gridCellOccupied[posX + mapSize * posZ] = true;

                int posX = UnityEngine.Random.Range(0, mapSize);
                int posZ = UnityEngine.Random.Range(0, mapSize);
                for (int k = -minRessourcesPackSize[i]; k <= minRessourcesPackSize[i]; k++)
                {
                    for (int l = -minRessourcesPackSize[i]; l <= minRessourcesPackSize[i]; l++)
                    {
                        if (posX + l + mapSize * (posZ + k) < 0 || posX + l + (posZ + k) * mapSize >= mapSize * mapSize || gridCellOccupied[posX + l + (posZ + k) * mapSize] == true)
                        {
                            posX = UnityEngine.Random.Range(0, mapSize); ;
                            posZ = UnityEngine.Random.Range(0, mapSize); ;
                            k = -minRessourcesPackSize[i];
                            l = -minRessourcesPackSize[i];
                        }
                    }
                }

                for (int k = -minRessourcesPackSize[i]; k < minRessourcesPackSize[i]; k++)
                {
                    for (int l = -minRessourcesPackSize[i]; l < minRessourcesPackSize[i]; l++)
                    {
                        if (posX + l + mapSize * (posZ + k) >= 0 && posX + l + (posZ + k) * mapSize < mapSize * mapSize && gridCellOccupied[posX + l + (posZ + k) * mapSize] == false)
                        {
                            if (UnityEngine.Random.Range(0, ressourcePackDensity * minRessourcesPackSize[i]) > Math.Max(Math.Abs(j), Math.Abs(k)))
                            {
                                GameObject go = Instantiate(ressources[i]);
                                gridCellOccupied[posX + k + (posZ + l) * mapSize] = true;
                                go.transform.position = new Vector3(posX + k + 0.5f, 0.5f, posZ + l + 0.5f);
                            }
                        }
                    }
                }

            }
        }
    }

    public void CreateBase()
    {
        int posX = UnityEngine.Random.Range(0+offsetWallBase, mapSize-offsetWallBase);
        int posZ = UnityEngine.Random.Range(0+offsetWallBase, mapSize-offsetWallBase); 
        for (int i=-baseSize; i<=baseSize;i++)
        {
            for(int j=-baseSize; j<=baseSize;j++)
            {
                if(gridCellOccupied[posX+j + (posZ+i) * mapSize] == true)
                {
                    posX = UnityEngine.Random.Range(0+offsetWallBase, mapSize-offsetWallBase);;
                    posZ = UnityEngine.Random.Range(0 + offsetWallBase, mapSize - offsetWallBase); ;
                    i = -baseSize;
                    j = -baseSize;
                }
            }
        }



        GameObject go = Instantiate(playerBase);

        for (int i = -baseSize; i <= baseSize; i++)
        {
            for (int j = -baseSize; j <= baseSize; j++)
            {
                gridCellOccupied[posX + j + (posZ + i) * mapSize] = true;
            }
        }
        go.transform.position = new Vector3(posX + 0.5f, 0, posZ + 0.5f);
        Debug.Log(go.transform.position);
    }


    private void CreateZombieSpawners()
    {
        for(int i = 0; i<zombieSpawnerAmount;i++)
        {
            int posX = UnityEngine.Random.Range(0 , mapSize);
            int posZ = UnityEngine.Random.Range(0 , mapSize);
            for (int j = -zombieSpawnerOffset; j <= zombieSpawnerOffset; j++)
            {
                for (int k = -zombieSpawnerOffset; k <= zombieSpawnerOffset; k++)
                {
                    if (posX + k + mapSize * (posZ + j) < 0 || posX + k + (posZ + j) * mapSize >= mapSize * mapSize || gridCellOccupied[posX + k + (posZ + j) * mapSize] == true)
                    {
                        posX = UnityEngine.Random.Range(0 , mapSize ); ;
                        posZ = UnityEngine.Random.Range(0 , mapSize ); ;
                        j = -zombieSpawnerOffset;
                        k = -zombieSpawnerOffset;
                    }
                }
            }

            for (int j = -baseSize; j <= baseSize; j++)
            {
                for (int k = -baseSize; k <= baseSize; k++)
                {
                    gridCellOccupied[posX + k + (posZ + j) * mapSize] = true;
                }
            }
            GameObject go = Instantiate(zombieSpawner);
            go.transform.position = new Vector3(posX + 0.5f, 0, posZ + 0.5f);
        }
    }
}
