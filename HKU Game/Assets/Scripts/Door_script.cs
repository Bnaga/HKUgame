using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door_script : MonoBehaviour {

    private int lvl;
    public GameController_script controllerScript;
    // Use this for initialization
    private TimeLimit_script timeScript;
	void Start ()
    {
        lvl = SceneManager.GetActiveScene().buildIndex;
        GameObject controller = GameObject.Find("GameController");
        controllerScript = controller.GetComponent<GameController_script>();
        if(SceneManager.GetActiveScene().buildIndex >= 5)
        {
            controllerScript.Invoke("BugPenalty", 0.5f);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && lvl == 7)
        {
            SceneManager.LoadScene(0);
        }
        else if (coll.gameObject.tag == "Player" && lvl < 19)
        {
            SceneManager.LoadScene(lvl + 1);
        }
        else if (coll.gameObject.tag == "Player" && lvl == 19 && controllerScript.score > 1000)
        {
            SceneManager.LoadScene(lvl + 1);
        }
        else if (coll.gameObject.tag == "Player" && lvl == 19 && controllerScript.score < 1000)
        {
            SceneManager.LoadScene(lvl + 2);
        }
    }
}
