﻿using UnityEngine;
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
        controllerScript.AddScore(-160);
	
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
        }
        else if(followPlayer == false)
        {
            transform.position = transform.position;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex >=4)
        {

            SceneManager.LoadScene(0) ;

        }
        else if(coll.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(1);
        }
        if(coll.gameObject.tag == "Shot")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            controllerScript.AddScore(160);
        }
    }


}
