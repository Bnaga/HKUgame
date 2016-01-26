using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bug_script : MonoBehaviour {
    bool followPlayer = false;
    private float moveSpeed = 10.0F;
    private float maxDistance = 10.0F;
    //private float minDistance = 5.0F;
    //GameObject player;
    private Rigidbody2D bug;
    public Transform target;
    public GameController_script controllerScript;
    private bool facingRight = true;
    private float playerX;
    private float bugX;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            followPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && (Vector3.Distance(transform.position, target.transform.position) > maxDistance))
        {
            followPlayer = false;
        }
    }

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject controller = GameObject.Find("GameController");
        controllerScript = controller.GetComponent<GameController_script>();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(followPlayer == true && (Vector3.Distance(transform.position,target.transform.position) <maxDistance))
        {
            Vector3 vectorToTarget = target.position - transform.position;
            float moveDistance = moveSpeed * Time.deltaTime;
            if (vectorToTarget.magnitude > moveDistance)
            {
                transform.position += vectorToTarget.normalized * moveDistance;
            }
            else {
                transform.position = target.position;
            }
            playerX = target.position.x;
            bugX = transform.position.x;

        }
        else if(followPlayer == false)
        {
            transform.position = transform.position;
        }
        if(!facingRight && playerX > bugX)
        {
            Flip();
        }
        if(facingRight && playerX < bugX)
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex >=8)
        {

            SceneManager.LoadScene(1) ;

        }
        else if(coll.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex < 8)
        {
            SceneManager.LoadScene(2);
        }
        if(coll.gameObject.tag == "Shot")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            controllerScript.AddScore(150);
        }
    }


}
