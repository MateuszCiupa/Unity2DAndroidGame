using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private Text coinText;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text distanceText;

    private int coins;
    private int maxHealthPoints;
    private int maxDistance;

    [SerializeField]
    private int startingHealthPoints = 2;

    [SerializeField]
    private int healthPointCost = 50;

    void Start() {
        Debug.Log("start!!!");
        LoadPlayerInventory();
    }

    public void SavePlayerInventory() {
        SaveSystem.SavePlayerData(new PlayerData(maxHealthPoints, coins, maxDistance));
    }

    public void LoadPlayerInventory() {
        PlayerData data = SaveSystem.LoadPlayerData();

        if(data != null) {
            coins = data.coins;
            maxHealthPoints = data.maxHealthPoints;
            maxDistance = data.maxDistance;
        } else {
            coins = 0;
            maxHealthPoints = startingHealthPoints;
            maxDistance = 0;
        }
    }

    public void WriteText() {
        if(coinText != null) {
            coinText.text = "Your Coins: " + coins.ToString();
        }

        if(healthText != null) {
            healthText.text = "Max Health: " + maxHealthPoints.ToString();
        }

        if(distanceText != null) {
            distanceText.text = "Max Distance: " + maxDistance.ToString();
        }
    }

    public void BuyHealthPoint() {
        if(coins >= healthPointCost) {
            maxHealthPoints++;
            coins -= healthPointCost;
            WriteText();
        }
    }

}
