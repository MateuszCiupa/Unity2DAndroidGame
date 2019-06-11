using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    [SerializeField]
    private Transform generationPoint;

    [SerializeField]
    public Transform maxHeightPoint;

    private float distanceBetween;
    private float platformWidth;

    [SerializeField]
    private float distanceBetweenMin;

    [SerializeField]
    private float distanceBetweenMax;

    [SerializeField]
    private ObjectPooler[] platformPoolers;

    [SerializeField]
    private ObjectPooler[] obstaclePoolers;

    private int platformSelector;
    private int obstacleSelector;

    private float minHeight;
    
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public GameObject lastRespawn;
    private bool wasObstacle;

    void Start() {
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        wasObstacle = false;
    }

    void Update() {
        if(transform.position.x < generationPoint.position.x) {
            platformSelector = Random.Range(0, platformPoolers.Length);
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformWidth = platformPoolers[platformSelector].pooledObject.GetComponent<BoxCollider2D>().size.x;

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

            if(heightChange > maxHeight) {
                heightChange = maxHeight;
            } else if(heightChange < minHeight) {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + platformWidth / 2 + distanceBetween, heightChange, transform.position.z);
            GameObject newPlatform = platformPoolers[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            transform.position = new Vector3(transform.position.x + platformWidth / 2, transform.position.y, 0f);

            obstacleSelector = Random.Range(0, obstaclePoolers.Length);

            if(wasObstacle) {
                lastRespawn = newPlatform;
            }

            if(!wasObstacle) {
                GameObject newObstacle = obstaclePoolers[obstacleSelector].GetPooledObject();
                newObstacle.transform.position = transform.position;
                newObstacle.transform.rotation = transform.rotation;

                if(obstacleSelector == obstaclePoolers.Length - 1) { // monetka
                    newObstacle.transform.position = new Vector3(transform.position.x - Random.Range(0, platformWidth), transform.position.y + 0.8f, transform.position.z);
                } else { // kolce
                    float spikesWidth = obstaclePoolers[obstacleSelector].pooledObject.GetComponent<BoxCollider2D>().size.x;
                    newObstacle.transform.position = new Vector3(transform.position.x - spikesWidth / 2 - Random.Range(0, platformWidth - spikesWidth), transform.position.y + 1.2f, transform.position.z);
                }

                newObstacle.SetActive(true);
            }

            wasObstacle = !wasObstacle;
        }
    }
}
