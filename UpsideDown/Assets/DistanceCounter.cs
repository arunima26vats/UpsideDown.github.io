using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public partial class DistanceCounter : MonoBehaviour
{
    public TextMeshProUGUI distanceText;   // Slot for current distance UI
    public TextMeshProUGUI highScoreText;  // Slot for the High Score UI
    private float distance;
    private int highScore;

    
void Start()
{
    // Load the BEST score once at the very start
    highScore = PlayerPrefs.GetInt("HighScore", 0);
    highScoreText.text = "BEST: " + highScore + "m";
}

void Update()
{
    if (Time.timeScale > 0)
    {
        // Only the DISTANCE should increase every frame
        distance += Time.deltaTime * 5;
        int currentDist = Mathf.FloorToInt(distance);
        distanceText.text = "DIST: " + currentDist + "m";

        // ONLY update BEST if you actually beat the record
        if (currentDist > highScore)
        {
            highScore = currentDist;
            highScoreText.text = "BEST: " + highScore + "m";
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
public void GoTohomescreen()
    {
        // Very important: Reset time scale to 1 so the game isn't frozen in the next scene
        Time.timeScale = 1; 
        SceneManager.LoadScene("homescreen");
    }
   /* public void RestartGame()
    {
        // 6. Unfreeze time and reload the scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}