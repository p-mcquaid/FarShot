using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public PlayerController player;
    public GameObject rightBound;
    public GameObject leftBound;
    public Renderer bg;

    private float bgSpeed;
    private Camera cam;
    private Vector3 lastPlayerPos;
    private float distanceToMove;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPos = player.transform.position;
        cam = GetComponent<Camera>();
        leftBound.transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        rightBound.transform.position = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        bgSpeed = 1.5f;
    }
	
	// Update is called once per frame
	void Update () {
        leftBound.transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        rightBound.transform.position = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        distanceToMove = player.transform.position.y - lastPlayerPos.y;
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);

        rightBound.transform.position = new Vector3(rightBound.transform.position.x, transform.position.y + distanceToMove -2.5f, rightBound.transform.position.z);
        leftBound.transform.position = new Vector3(leftBound.transform.position.x, transform.position.y + distanceToMove -2.5f, leftBound.transform.position.z);

        lastPlayerPos = player.transform.position;

        Vector2 offset = new Vector2(0, Time.time * bgSpeed);
        bg.material.mainTextureOffset = offset;
	}

    public float getLeftBound()
    {
        float left = leftBound.transform.position.x;
        return left;
    }

    public float getRighttBound()
    {
        float x = rightBound.transform.position.x;
        return x;
    }
}
