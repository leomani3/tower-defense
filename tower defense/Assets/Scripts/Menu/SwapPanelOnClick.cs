using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapPanelOnClick : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject panelToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapPanel()
    {
        panelToDisplay.SetActive(true);
        currentPanel.SetActive(false);
    }
}
