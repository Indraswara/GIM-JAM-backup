using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private TextMeshProUGUI coinsText;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            coins++;
            coinsText.text = "Coins: " + coins;
        }
    }
}
