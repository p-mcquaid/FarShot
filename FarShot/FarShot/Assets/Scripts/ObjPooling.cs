using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour {

    public GameObject objPool;

    public int poolAmt;
    List<GameObject> pooledObjs;
	// Use this for initialization
	void Start () {
        pooledObjs = new List<GameObject>();

        for (int i = 0; i < poolAmt; i++)
        {
            GameObject x = (GameObject)Instantiate(objPool);
            x.SetActive(false);
            pooledObjs.Add(x);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetPooledObj()
    {
        for (int i = 0; i < pooledObjs.Count; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
            
        }
        GameObject x = (GameObject)Instantiate(objPool);
        x.SetActive(false);
        pooledObjs.Add(x);
        return x;
    }

}
