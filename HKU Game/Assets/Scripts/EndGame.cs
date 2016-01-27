using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    void Start()
    {
        Destroy(GameObject.Find("GameController"));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
