using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {
    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();	
	}
	
	public void leftArrow()
    {
        player.Move(-1);
        Debug.Log("Left Arrow Pressed");
    }

    public void rightArrow()
    {
        player.Move(1);
    }

    public void noArrow()
    {
        player.Move(0);
        Debug.Log(" Arrow Unpressed");
    }
}
