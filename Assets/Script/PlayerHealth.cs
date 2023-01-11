using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        
        if(health <= 0)
        {
            healthText.text = "Health: 0";
            gameObject.SetActive(false);
            Invoke("RestartLevel", 1);
        }
        else
            healthText.text = "Health: " + health;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
