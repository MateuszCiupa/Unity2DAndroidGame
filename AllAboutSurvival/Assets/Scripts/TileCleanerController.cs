using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCleanerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Platform") {
            other.gameObject.SetActive(false);
        }
    }
}
