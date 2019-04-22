using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;
    
    public void Pause()
    {

    }

    public void Resume() { }


    public void Restart()
    {
        FindObjectOfType<GameManager>().ResetGame();
    }

    public void Quit()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
