using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;

    private int levelToLoad;

    public void fadeToLevel(int lvlIndex)
    {
        levelToLoad = lvlIndex;
        animator.Play("Fade_Out");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
