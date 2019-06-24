using UnityEngine.UI;
using UnityEngine;

public class Player : Unit
{
    public Image modeImage;
    
    private int mode = 1; //1: action 2: construction

    // Start is called before the first frame update
    void Start()
    {
        modeImage.color = new Color(1, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeMode();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            TakeDamage(1);
        }


    }

    public void ChangeMode()
    {
        if(mode == 1)
        {
            mode = 2;
            modeImage.color = new Color(0, 1, 1, 1);
        }
        else if (mode == 2)
        {
            mode = 1;
            modeImage.color = new Color(1, 0, 0, 1);
        }
    }

    public void Attack()
    {

    }

    public void Construct()
    {

    }
}
