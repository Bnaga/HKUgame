using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenu_script : MonoBehaviour {

    void Start()
    {
        Destroy(GameObject.Find("GameController"));
    }

	public void StartGame()
    {
        SceneManager.LoadScene(8);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
