using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Transform playerPos;
    public float playerMoveSpeed = 40f;
    public float asteroidAmtMilestone;
    public GenerateAsteroids genAst;
    public CharacterController2D controller;
    public GameManager gameManager;
    public float asteroidAmtCount;
    public GameObject[] arrows;

    private float moveHorizontal;
    private Vector2 origin;
    private Rigidbody2D mrb;

	// Use this for initialization
	void Start () {
        mrb = GetComponent<Rigidbody2D>();
        origin = -Vector2.one;
        asteroidAmtCount = asteroidAmtMilestone;

        
    }
	
    void FixedUpdate()
    {
        mrb.velocity = new Vector2(mrb.velocity.x, 3);
#if UNITY_ANDROID || UNITY_iOS
 
#endif

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDIOTR

        Move(Input.GetAxisRaw("Horizontal"));
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].gameObject.SetActive(false);
        }
#endif
        if (transform.position.y >= asteroidAmtCount)
        {
            asteroidAmtCount += asteroidAmtMilestone;

            if (genAst.distMax > genAst.distMin)
            {
                genAst.distMax--;
            }
        }
   
    }

    public void Move(float moveInput)
    {
    
       

        moveHorizontal = moveInput * playerMoveSpeed;

        controller.Move(moveHorizontal * Time.fixedDeltaTime, false, false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Asteroids")
        {
            gameManager.restartGame();
        }
    }
}
