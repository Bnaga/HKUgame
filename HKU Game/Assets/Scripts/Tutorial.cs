using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    private int lvl;
    void Start()
    {
        lvl = SceneManager.GetActiveScene().buildIndex;
    }

    public void Continue()
    {
        SceneManager.LoadScene(lvl + 1);
    }
}
