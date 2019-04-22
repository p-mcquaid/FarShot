using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    // Use this for initialization
    public string mainMenu;
    public LevelChanger levelChanger;

    public void Restart()
    {
        FindObjectOfType<GameManager>().ResetGame();
    }

    public void Quit()
    {
        levelChanger.fadeToLevel(0);
    }
}
