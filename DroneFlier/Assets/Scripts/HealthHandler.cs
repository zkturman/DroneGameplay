using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private int baseHealth = 5;
    private int currentHealth;
    [SerializeField]
    private UIManager uiManager;

    private void Awake()
    {
        currentHealth = baseHealth;
        uiManager.SetHealth(currentHealth);
    }

    public void ReduceHealth()
    {
        currentHealth--;
        uiManager.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Debug.Log("GameOver");
        }
    }
}
