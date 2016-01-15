using UnityEngine;
using System.Collections;

public class Edit_script : MonoBehaviour {

    private Player_script playScript;
    public bool editTxt = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        playScript = player.GetComponent<Player_script>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject coder = GameObject.Find("Code");
            if(editTxt == true && playScript.jumpCount == 0)
            {
                    playScript.normal = coll.contacts[0].normal;
                    if (playScript.normal.y < 0)
                    {
                        playScript.jumpCount += 2;
                    }

            }
            else if (editTxt == true && playScript.jumpCount == 1)
            {
                playScript.normal = coll.contacts[0].normal;
                if (playScript.normal.y < 0)
                {
                    playScript.jumpCount += 1;
                }

            }
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playScript.normal = coll.contacts[0].normal;
            if (playScript.normal.x > 0 || playScript.normal.x < 0)
                playScript.sideTouch = false;
            editTxt = false;
        }
    }

}
