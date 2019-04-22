using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyAsteroid : MonoBehaviour {

    public GameObject astDstyPoint;
    // Use this for initialization
    void Start () {
        astDstyPoint = GameObject.Find("AsteroidDestPoint");
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < astDstyPoint.transform.position.y)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    
}
