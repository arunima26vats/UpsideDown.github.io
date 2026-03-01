using UnityEngine;
using TMPro;

public class TextGlitch : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private Vector3 originalPosition;
    public float glitchIntensity = 5f;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // We use unscaledDeltaTime because the game is frozen (Time.timeScale = 0)
        // This allows the animation to keep playing while the game is stopped!
        float offsetX = Random.Range(-glitchIntensity, glitchIntensity);
        float offsetY = Random.Range(-glitchIntensity, glitchIntensity);
        
        transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);

        // Optional: Make the color flicker between Red and Dark Red
        textMesh.color = (Random.value > 0.7f) ? Color.red : new Color(0.5f, 0, 0);
    }
}