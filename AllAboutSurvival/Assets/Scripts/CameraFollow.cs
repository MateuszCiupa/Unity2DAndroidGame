using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform followed;

    void Update() {
        if(followed != null) {
            transform.position = new Vector3(followed.position.x, followed.position.y, -10f);
        } 
    }
}
