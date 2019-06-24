using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : Unit
{

    public int costWood;
    public int costStone;
    public int costIron;
    public int costCopper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
