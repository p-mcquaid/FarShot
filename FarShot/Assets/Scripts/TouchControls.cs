using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {
    private PlayerController player;

    public bool isMute;
    public AudioSource[] gameSounds;


	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();	
	}
	
	public void leftArrow()
    {
        player.Move(-1);
        Debug.Log("Left Arrow Pressed");
        if (!isMute)
        {
            gameSounds[0].Play();
        }
    }

    public void rightArrow()
    {
        player.Move(1);
        if (!isMute)
        {
            gameSounds[1].Play();
        }
    }

    public void noArrow()
    {
        player.Move(0);
        Debug.Log(" Arrow Unpressed");
    }
}
