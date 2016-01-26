using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour 
{

    public float maxSpeed = 10.0f;
    public float jumpSpeed = 20.0f;
    //public float gravity = 0.01f;
    bool facingRight = true;
    private Rigidbody2D playerBody;
    //bool grounded =false;
    public int jumpCount = 2;
    public Vector2 normal;
    public bool sideTouch = false;
    //public bool unCode = false;
    public Rigidbody2D debugShot;
    private float bulletSpeed = 800.0f;
    private float cooldown = -3.0f;
    private float bulletHealth = 1.0f;
    private float xShot = 1.5f;
    private AudioSource shotsrc;
    public AudioClip shotClip;
    public AudioClip jumpClip;
    public AudioClip codeClip;
    public AudioClip editClip;
    public GameController_script controllerScript;

    void Awake()
    {
         shotsrc = GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        cooldown = Time.time + 1;
        GameObject controller = GameObject.Find("GameController");
        controllerScript = controller.GetComponent<GameController_script>();
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
        
       /* if(playerBody.velocity.x < 0)
        {
            facingRight = false;
            Debug.Log("face left");
        } 

        else if(playerBody.velocity.x > 0)
        {
            facingRight = true;
            Debug.Log("face right");
        } */

        //when jumpbutton/spacebar is pressed, player jumps and loses one jumpcount.
        if (Input.GetButtonDown("Jump") && jumpCount >= 1)
        {
            playerBody.velocity = new Vector2(move * maxSpeed, jumpSpeed);
            shotsrc.PlayOneShot(jumpClip, 0.6f);
            jumpCount -= 1;
        }

        if (Time.time >= cooldown)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                cooldown = cooldown + 1;
                Fire();
            }
        }

        if(facingRight && playerBody.velocity.x < 0)
        {
            Flip();
        }

        if(!facingRight && playerBody.velocity.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Fire()
    {
        if(facingRight == true)
        {
            Rigidbody2D bugshot = Instantiate(debugShot, new Vector3(transform.position.x + xShot, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
            bugshot.AddForce(transform.right * bulletSpeed);
            shotsrc.PlayOneShot(shotClip, 1.0f);
            Destroy(bugshot.gameObject, bulletHealth);
        }

        else if(facingRight == false)
        {
            Rigidbody2D bugshot = Instantiate(debugShot, new Vector3(transform.position.x - xShot, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
            bugshot.AddForce(-transform.right * bulletSpeed);
            shotsrc.PlayOneShot(shotClip, 1.0f);
            Destroy(bugshot.gameObject, bulletHealth);
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
                shotsrc.PlayOneShot(editClip, 1.0f);
                controllerScript.AddScore(100);
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

        if (coll.gameObject.tag == "Code")
        {
            shotsrc.PlayOneShot(codeClip, 0.5f);
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
