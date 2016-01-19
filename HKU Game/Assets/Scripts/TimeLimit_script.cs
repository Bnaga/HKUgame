using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeLimit_script : MonoBehaviour {

    public float startTime;
    private float timeRemaining;
    private float percent;
    public bool clockIsPaused;
    private ProgressBar.ProgressBarBehaviour barbar;

	// Use this for initialization
	void Start ()
    {
        //startTime = 600.0F;
        startTime = 40.0F;
        timeRemaining = startTime-Time.realtimeSinceStartup;
        GameObject bar = GameObject.FindGameObjectWithTag("Bar");
        barbar = bar.GetComponent <ProgressBar.ProgressBarBehaviour> ();        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(clockIsPaused == false)
        {
            CountDown();
        }

	}

    void CountDown()
    {
        timeRemaining -= Time.deltaTime;
        percent = timeRemaining / startTime * 100;

        if(timeRemaining < 0)
        {
            timeRemaining = 0;
            clockIsPaused = true;
            SceneManager.LoadScene(0);
        }
        ShowTime();
    }

    void ShowTime()
    {
        barbar.Value = percent;
    }
}
