using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; 
    public int health; 
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage; 
        healthText.text = "Health: " + health;
        
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
