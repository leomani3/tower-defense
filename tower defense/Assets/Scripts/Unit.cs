using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int maxHealth;
    public Image healthBar;
    public Canvas HUD;
    private int currentHealth;

    protected void Update()
    {
        CheckIfDie(); // nécessaire?
        UpdateHUDRotation();
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// regarde si la vie du zombie est a zéro. si oui, destroy le gameobject
    /// </summary>
    protected void CheckIfDie()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //TODO : il faudra surement remplacer Destroy pas Disable certaisn script, jouer un son, puis destroy.
        }
    }

    public void TakeDamage(int value)
    {
        currentHealth -= value;
        CheckIfDie();
        Debug.Log("current health : " + CurrentHealth + "\nMax Haelth : " + maxHealth);
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    public void UpdateHUDRotation()
    {
        HUD.transform.eulerAngles = new Vector3(40, 0, 0);
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }
}
