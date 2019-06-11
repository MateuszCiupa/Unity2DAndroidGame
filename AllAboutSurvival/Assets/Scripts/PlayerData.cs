using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    
    public int maxHealthPoints;
    public int coins;
    public int maxDistance;

    public PlayerData(PlayerInventory playerInventory) {
        maxHealthPoints = playerInventory.maxHealthPoints; 
        coins = playerInventory.coins;
        maxDistance = playerInventory.maxDistance;
    }

    public PlayerData(int maxHealthPoints, int coins, int maxDistance) {
        this.maxHealthPoints = maxHealthPoints;
        this.coins = coins;
        this.maxDistance = maxDistance;
    }

}
