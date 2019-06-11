using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    [SerializeField]   
    private Text coinText;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text distanceText;

    private int healthPoints; 
    private int coinsGathered;
    private int distance;

    [SerializeField]
    private int maxCoinsValue = 10000;

    [SerializeField]
    private int maxHealthPointsValue = 10000;

    [SerializeField]
    private int maxDistanceValue = 10000;

    [SerializeField]
    private int startingHealthPoints = 2;

    [HideInInspector]
    public int coins;

    [HideInInspector]
    public int maxDistance;

    [HideInInspector]
    public int maxHealthPoints;

    [SerializeField]
    private Text onDeathDistanceText;

    [SerializeField]
    private Text onDeathCoinsText;

    [SerializeField]
    private Text onDeathMaxDistanceText;

    void Start() {
        LoadPlayerInventory();

        coinsGathered = 0;

        if(coinText != null) {
            coinText.text = coinsGathered.ToString();
        }

        healthPoints = maxHealthPoints;

        if(healthText != null) {
            healthText.text = healthPoints.ToString();
        }

        distance = 0;

        if(distanceText != null) {
            distanceText.text = distance.ToString();
        }
    }

    void Update() {
        int position = (int)transform.position.x;
        distance = position > distance ? position : distance;

        if(distanceText != null) {
            distanceText.text = distance.ToString();
        }
    }

    public void AddCoin() {
        int add = coinsGathered > maxCoinsValue ? 0 : 1;
        coinsGathered += add;

        if(coinText != null) {
            coinText.text = coinsGathered.ToString();
        }
    }

    public int RemoveHealth() {
        healthPoints--;

        if(healthText != null) {
            healthText.text = healthPoints.ToString();
        }

        return healthPoints;
    }

    public void SavePlayerInventory() {
        coins = coins + coinsGathered > maxCoinsValue ? maxCoinsValue : coins + coinsGathered;
        maxDistance = distance > maxDistance ? distance : maxDistance;
        SaveSystem.SavePlayerData(this);
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

    public void WriteOnDeathData() {
        if(onDeathCoinsText != null) {
            onDeathCoinsText.text = "Coins: " + coinsGathered.ToString();
        }

        if(onDeathDistanceText != null) {
            onDeathDistanceText.text = "Distance: " + distance.ToString();
        }

        if(onDeathMaxDistanceText != null) {
            onDeathMaxDistanceText.gameObject.SetActive(distance > maxDistance ? true : false);
        }

        SavePlayerInventory();
    }
}
