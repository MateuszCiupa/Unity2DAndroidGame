using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    [SerializeField]
    private Transform followed;

    void Update() {
        if(followed != null) {
            transform.position = new Vector3(followed.position.x, transform.position.y, followed.position.z);
        }
    }
}
