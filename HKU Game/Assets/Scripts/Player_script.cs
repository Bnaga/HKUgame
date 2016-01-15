using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {

    public float maxSpeed = 10.0F;
    public float jumpSpeed = 15.0F;
    //public float gravity = 0.01F;
    bool facingRight = true;
    private Rigidbody2D playerBody;
    //bool grounded =false;
    private int jumpCount = 2;
    private Vector2 normal;
    private bool sideTouch = false;

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {
            normal = coll.contacts[0].normal;
            if (normal.x > 0 || normal.x < 0)
               sideTouch = true;
        }
            
    } 

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform" && jumpCount == 0)
        {
            normal = coll.contacts[0].normal;
            if (normal.y > 0)
            {
                jumpCount += 2;
            }
                 
        }
        else if (coll.gameObject.tag == "Platform" && jumpCount == 1)
        {
            normal = coll.contacts[0].normal;
            if (normal.y > 0)
            {
                jumpCount += 1;
            }

        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform" )
        {
            normal = coll.contacts[0].normal;
            if (normal.x > 0 || normal.x < 0)
                sideTouch = false;
        }
    } 

    // Use this for initialization
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");

        if (sideTouch == false)
        {
            playerBody.velocity = new Vector2(move * maxSpeed, playerBody.velocity.y);
        }
        

 
        if (Input.GetButtonDown("Jump") && jumpCount >= 1)
        {
            playerBody.velocity = new Vector2(move * maxSpeed, jumpSpeed);

            jumpCount -= 1;
        }

	}

}
