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
        //when collision with player bottom and jumcount equals 0, add 2 two player's jumpcount
        if (coll.gameObject.tag == "Player")
        {
            if( playScript.jumpCount == 0)
            {
                    playScript.normal = coll.contacts[0].normal;
                    if (playScript.normal.y < 0)
                    {
                        playScript.jumpCount += 2;
                    }

            }
            //when collision with player bottom and jumcount equals 1, add 1 two player's jumpcount
            else if ( playScript.jumpCount == 1)
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
        //when collision exit with player bottom, edit text is set to false and side touch in player script is set to false
        if (coll.gameObject.tag == "Player")
        {
            playScript.normal = coll.contacts[0].normal;
            if (playScript.normal.x > 0 || playScript.normal.x < 0)
                playScript.sideTouch = false;
            //editTxt = false;
        }
    }

}
