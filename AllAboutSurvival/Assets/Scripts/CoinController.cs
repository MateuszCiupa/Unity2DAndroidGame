using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.gameObject.GetComponent<PlayerInventory>().AddCoin();
            MakeDead();
        }    
    }

    public void MakeDead() {
        //Destroy(gameObject.transform.parent.gameObject);
        gameObject.SetActive(false);
    }
}
