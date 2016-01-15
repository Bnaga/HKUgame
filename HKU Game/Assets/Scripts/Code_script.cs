using UnityEngine;
using System.Collections;

public class Code_script : MonoBehaviour
{

    public bool unCode = false;
    private Edit_script editText;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            unCode = true;
        }
    }
    // Use this for initialization
    void Start ()
    {
        GameObject edit = GameObject.Find("EditCode");
        editText = edit.GetComponent<Edit_script>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void WriteCode()
    {
        editText.editTxt = true;
        Debug.Log("editTxt true");
        if(editText.editTxt == true)
        {
            gameObject.SetActive(false);
        }
      
    }
}
