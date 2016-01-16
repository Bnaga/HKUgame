using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour 
{

    public float maxSpeed = 10.0F;
    public float jumpSpeed = 15.0F;
    //public float gravity = 0.01F;
    bool facingRight = true;
    private Rigidbody2D playerBody;
    //bool grounded =false;
    public int jumpCount = 2;
    public Vector2 normal;
    public bool sideTouch = false;
    //public bool unCode = false;

    // Use this for initialization
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");

        //if player is not touching side of platform, player can move horizontally
        if (sideTouch == false)
        {
            playerBody.velocity = new Vector2(move * maxSpeed, playerBody.velocity.y);
        }
        

        //when jumpbutton/spacebar is pressed, player jumps and loses one jumpcount.
        if (Input.GetButtonDown("Jump") && jumpCount >= 1)
        {
            playerBody.velocity = new Vector2(move * maxSpeed, jumpSpeed);

            jumpCount -= 1;
        }

	}

    void OnCollisionStay2D(Collision2D coll)
    {
        //on collision with sides of platform, set sideTouch to true
        if (coll.gameObject.tag == "Platform")
        {
            normal = coll.contacts[0].normal;
            if (normal.x > 0 || normal.x < 0)
                sideTouch = true;
        }
        //on collision with code, if f key is pressed, code becomes inactive
        if (coll.gameObject.tag == "Code")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                coll.gameObject.SetActive(false);
            }
            //on collision with sides of platform, set sideTouch to true
            normal = coll.contacts[0].normal;
            if (normal.x > 0 || normal.x < 0)
                sideTouch = true;

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //if double jump was used and player has collison with platform top, add more jumpCounts
        if (coll.gameObject.tag == "Platform" && jumpCount == 0)
        {
            normal = coll.contacts[0].normal;
            if (normal.y > 0)
            {
                jumpCount += 2;
            }

        }
        //if jump was used and player has collison with platform top, add 1 more jumpCount
        else if (coll.gameObject.tag == "Platform" && jumpCount == 1)
        {
            normal = coll.contacts[0].normal;
            if (normal.y > 0)
            {
                jumpCount += 1;
            }

        }
       

}
    //when collision is exited
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "Code")
        {
            normal = coll.contacts[0].normal;
            if (normal.x > 0 || normal.x < 0)
                sideTouch = false;
        }
    }
}
