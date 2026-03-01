using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void GoToScene1()
    {
        // Very important: Reset time scale to 1 so the game isn't frozen in the next scene
        Time.timeScale = 1; 
        SceneManager.LoadScene("homescreen");
    }
}