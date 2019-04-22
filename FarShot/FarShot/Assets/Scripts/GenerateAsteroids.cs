using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour {
    //public GameObject[] asteroids;
    public Transform genPoint;
    public float distBetween;

    public ObjPooling[] objPools;
    public CameraFollow cam;

    public float distMin;
    public float distMax;

    private float[] asteroidWidth;
    private float asteroidX;
    private int asterSelect;
    //private Quaternion asteroidZ;
    private Vector3 euler;
	// Use this for initialization
	void Start () {

        //asteroidWidth[i] = asteroids[i].GetComponent<BoxCollider2D>().size.x;
        euler.z = Random.Range(0f, 360f);

        asteroidWidth = new float[objPools.Length];
        for (int i = 0; i < objPools.Length; i++)
        {
            asteroidWidth[i] = objPools[i].objPool.GetComponent<BoxCollider2D>().size.x;
        }
        
        distMin = 0; distMax = 5;

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < genPoint.position.y)
        {
            distBetween = Random.Range(distMin, distMax);
            asteroidX = Random.Range(cam.getLeftBound(), cam.getRighttBound());
            asterSelect = Random.Range(0, objPools.Length);
            //asteroidZ = Random.rotation;
            euler.z = Random.Range(0f, 360f);

            transform.position = new Vector3(asteroidX, transform.position.y + (asteroidWidth[asterSelect]/2) + distBetween, transform.position.z);
            transform.eulerAngles = euler;
            //Instantiate(objPools[asterSelect], transform.position, transform.rotation);

            GameObject newAster = objPools[asterSelect].GetPooledObj();
            newAster.transform.position = transform.position;
            newAster.transform.rotation = transform.rotation;
            newAster.SetActive(true);

            transform.position = new Vector3(asteroidX, transform.position.y + (asteroidWidth[asterSelect] / 2), transform.position.z);

        }


    }
}
