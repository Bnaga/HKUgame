using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {

    public float maxSpeed = 10.0F;
    public float jumpSpeed = 10.0F;
    //public float gravity = 20.0F;
    bool facingRight = true;
    private Rigidbody2D playerBody;
    bool grounded =false;

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
            grounded = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
            grounded = false;
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

        playerBody.velocity = new Vector2(move * maxSpeed, playerBody.velocity.y);

        if ( Input.GetButton("Jump") && grounded )
        {
            playerBody.velocity = new Vector2( move  * maxSpeed, jumpSpeed);
        }

	}


}
