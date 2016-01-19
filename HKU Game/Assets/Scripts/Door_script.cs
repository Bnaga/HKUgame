using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door_script : MonoBehaviour {

    private int lvl;
    // Use this for initialization
    private TimeLimit_script timeScript;
	void Start ()
    {
        lvl = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvl + 1);
        }
    }
}
