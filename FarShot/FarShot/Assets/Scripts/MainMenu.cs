using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Renderer bg;
    public string playGameScene;

    private float bgSpeed;

    // Use this for initialization
    void Start()
    {
        bgSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * bgSpeed);
        bg.material.mainTextureOffset = offset;

    }
    public void playGame()
    {
        SceneManager.LoadScene(playGameScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
