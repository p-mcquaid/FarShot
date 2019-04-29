using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Renderer bg;
    public string playGameScene;
    public AudioSource mainTheme;
    public LevelChanger levelChanger;


    private float bgSpeed;

    // Use this for initialization
    void Start()
    {
        bgSpeed = 1.5f;
        mainTheme.Play();
        StartCoroutine("ShowBannerAd");
        
    }

    IEnumerator ShowBannerAd()
    {
        yield return new WaitForSeconds(1.0f);
        AdManager.adManager.ShowBanner();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * bgSpeed);
        bg.material.mainTextureOffset = offset;

    }
   public void bannerPressed()
    {
        Analytics.CustomEvent("Banner Ad Pressed");
    }

    public void Mute()
    {
        if (mainTheme.isPlaying)
        {
            mainTheme.Stop();
            
            Debug.Log("Playing; " + mainTheme.isPlaying);

        }
        else if (!mainTheme.isPlaying)
        {
            mainTheme.Play();
            Debug.Log("Playing; " + mainTheme.isPlaying);
        }
    }

    public void playGame()
    {
        levelChanger.fadeToLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
