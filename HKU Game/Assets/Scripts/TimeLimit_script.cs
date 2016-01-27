using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeLimit_script : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(GameObject.Find("CountBar"));
    }
    static public float startTime;
    private float timeRemaining;
    private float percent;
    public bool clockIsPaused;
    private ProgressBar.ProgressBarBehaviour barbar;
    public bool retry = false;


	// Use this for initialization
	void Start ()
    {
        startTime = 230.0F;
        //startTime = 40.0F;
        timeRemaining = startTime;
        GameObject bar = GameObject.FindGameObjectWithTag("Bar");
        barbar = bar.GetComponent<ProgressBar.ProgressBarBehaviour>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(clockIsPaused == false)
        {
            CountDown();
        }

        if(SceneManager.GetActiveScene().buildIndex < 3 || SceneManager.GetActiveScene().buildIndex >=20 )
        {
            Destroy(GameObject.Find("Time"));
            Destroy(GameObject.Find("CountBar"));
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
