using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform asteroidGen;
    public PlayerController player;
    public GenerateAsteroids genAsteroid;
    public DeathMenu deathMenu;
    public string mainMenu;
    public GameObject pauseMenu;
    public LevelChanger levelChanger;

    private TouchControls touchControls;
    private bool isPause;
    private Score scoreManager;
    private Vector3 asteroidStartPoint;
    private Vector3 playerStartPoint;
    private float time;
    private DestroyAsteroid[] asteroidList;
    private bool isAd = false;


    
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
        touchControls = FindObjectOfType<TouchControls>();
        isPause = false;

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Pause();
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            Resume();
            isPause = false;
        }
        time += Time.deltaTime;

        //Debug.Log(time);
	}

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Mute()
    {
        if (touchControls.isMute)
        {
            touchControls.isMute = false;
        }
        else if (!touchControls.isMute)
        {
            touchControls.isMute = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        
        FindObjectOfType<GameManager>().ResetGame();
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        levelChanger.fadeToLevel(0);
        pauseMenu.SetActive(false);
    }

    public void restartGame()
    {
        scoreManager.isScoring = false;
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);

    }

    public void Continue()
    {

        AdManager.adManager.ShowRewardedAd();

        deathMenu.gameObject.SetActive(false);
        asteroidList = FindObjectsOfType<DestroyAsteroid>();
        for (int i = 0; i < asteroidList.Length; i++)
        {
            asteroidList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        asteroidGen.position = asteroidStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.isScoring = true;
        genAsteroid.distMax = 5;

    }
    public void ResetGame()
    {
        AdManager.adManager.ShowAd();
       
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
    void OnApplicationQuit()
    {
        AnalyticsEvent.GameOver("Game was quit");
    }
}
