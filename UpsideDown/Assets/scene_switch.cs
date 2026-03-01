using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour // Must inherit from MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "scene2";

    // This runs when something with a Collider2D enters this object's Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object touching this is actually the Player
        if (other.CompareTag("Player"))
        {
            SwitchScene();
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}