using UnityEngine;
using UnityEngine.SceneManagement; // Important: This allows scene switching

public class SceneSwitcher : MonoBehaviour
{
    public void LoadSceneOne()
    {
        SceneManager.LoadScene("scene1"); 
        // Note: Use the exact name of your scene inside the quotes
    }
}