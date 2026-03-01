using UnityEngine;
using UnityEngine.Rendering.Universal; // Essential for Unity 6 2D Lights

public class LightFlicker : MonoBehaviour
{
    private Light2D myLight;
    void Start() { myLight = GetComponent<Light2D>(); }
    void Update() {
        // This creates a fast, spooky flickering intensity
        myLight.intensity = Random.Range(0.8f, 2.0f);
    }
}