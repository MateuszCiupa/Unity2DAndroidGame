using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount;
    private List<GameObject> pooledObjects;

    void Start() {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        for(int i = 0; i < pooledAmount; i++) {
            if(!pooledObjects[i].activeInHierarchy) {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        Debug.Log("daj mnie!!!");
        
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        pooledAmount++;
        return obj;
    }
}
