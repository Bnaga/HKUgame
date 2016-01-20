using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverTut_script : MonoBehaviour {

    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
        if (GUI.Button(new Rect(Screen.width / 2 - 150 / 2, Screen.height / 2 + 50, 150, 25), "Retry"))
        {
            SceneManager.LoadScene(3);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150 / 2, Screen.height / 2 + 75, 150, 25), "Exit"))
        {
            Application.Quit();
        }
    }
}
