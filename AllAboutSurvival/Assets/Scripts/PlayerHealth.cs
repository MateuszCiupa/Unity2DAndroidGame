using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private Image deathScreen;

    [SerializeField]
    private CanvasGroup endCG;

    [SerializeField]
    private CanvasGroup playerCG;

    [SerializeField]
    private PlatformGenerator platformGenerator;

    public void MakeDead() {
        int healthPoints = GetComponent<PlayerInventory>().RemoveHealth();

        if(healthPoints == 0) {
            if(deathScreen != null) {
                deathScreen.color = Color.white;
            }

            if(endCG != null) {
                endCG.alpha = 1;
                playerCG.alpha = 0;
            }

            //Destroy(gameObject);
            gameObject.GetComponent<PlayerInventory>().WriteOnDeathData();
            gameObject.SetActive(false);
        } else {
            transform.position = new Vector3(platformGenerator.lastRespawn.transform.position.x, platformGenerator.lastRespawn.transform.position.y + 2, platformGenerator.lastRespawn.transform.position.z);
        }

        
    }
}
