using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenu_script : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene(4);
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
