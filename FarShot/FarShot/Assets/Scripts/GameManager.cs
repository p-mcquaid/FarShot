using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform asteroidGen;
    public PlayerController player;
    public GenerateAsteroids genAsteroid;
    public DeathMenu deathMenu;

    private Score scoreManager;
    private Vector3 asteroidStartPoint;
    private Vector3 playerStartPoint;

    private DestroyAsteroid[] asteroidList;

    void Awake()
    {
        //Screen.SetResolution(360, 740, false);

    }

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        asteroidStartPoint = asteroidGen.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restartGame()
    {
        scoreManager.isScoring = false;
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);

    }

    public void ResetGame()
    {
        //yield return new WaitForSeconds(1.5f);
        deathMenu.gameObject.SetActive(false);
        asteroidList = FindObjectsOfType<DestroyAsteroid>();
        for (int i = 0; i < asteroidList.Length; i++)
        {
            asteroidList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        asteroidGen.position = asteroidStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.isScoring = true;
        player.asteroidAmtCount = 0;
        genAsteroid.distMax = 5;
    }

}
