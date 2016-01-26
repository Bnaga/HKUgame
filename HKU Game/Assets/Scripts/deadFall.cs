using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class deadFall : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex >= 4)
        {

            SceneManager.LoadScene(1);

        }
        else if (coll.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(2);
        }
    }
}
