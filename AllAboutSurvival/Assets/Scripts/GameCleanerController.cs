using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleanerController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.GetComponent<PlayerHealth>().MakeDead();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        SceneManager.LoadScene("Menu");
    }
}
