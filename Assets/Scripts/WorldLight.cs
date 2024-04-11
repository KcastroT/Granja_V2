using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime {
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour {
        public float duration = 1f;
        [SerializeField] private Gradient gradient;
        private Color showShadowColor; // Color object for the specific hexadecimal color
        private Light2D _light;
        private float _startTime;
        private float percentage;
        [SerializeField] public bool running;

        private GameObject sombras; // Reference to the parent GameObject containing freeform shadows

        private void Awake() {
            _light = GetComponent<Light2D>();
            sombras = GameObject.Find("sombras"); // Find the parent GameObject by name
            running = false;
        }

        private void Update() {
            if (running) {
                float timeElapsed = Time.time - _startTime;
                percentage = (Mathf.Sin(2 * (timeElapsed / duration * Mathf.PI)) / 2) + 0.5f;
                _light.color = gradient.Evaluate(percentage);

                // Define the range of colors around F8D858
                Color targetColor = HexToColor("F8D858");
                float tolerance = 0.2f; // Adjust this tolerance to define the range

                // Check if the current gradient color is within the range of targetColor
                if (IsColorInRange(_light.color, targetColor, tolerance)) {
                    ShowFreeformShadows();
                } else {
                    HideFreeformShadows();
                }

                if (timeElapsed >= 3f) {
                    running = false;
                }
            }
        }

        public void StartCycle() {
            _startTime = Time.time;
            running = true;
        }

        // Function to convert hexadecimal string to Color object
        private Color HexToColor(string hex) {
            Color color;
            if (ColorUtility.TryParseHtmlString("#" + hex, out color)) {
                return color;
            } else {
                Debug.LogError("Invalid hexadecimal color: " + hex);
                return Color.white; // Return default color if parsing fails
            }
        }

        // Function to check if a color is within a range of another color
        private bool IsColorInRange(Color color, Color targetColor, float tolerance) {
            // Calculate the difference between the color components
            float rDiff = Mathf.Abs(color.r - targetColor.r);
            float gDiff = Mathf.Abs(color.g - targetColor.g);
            float bDiff = Mathf.Abs(color.b - targetColor.b);

            // Check if all components are within the tolerance range
            return rDiff <= tolerance && gDiff <= tolerance && bDiff <= tolerance;
        }

        // Function to hide freeform shadows
        private void HideFreeformShadows() {
            // Iterate through child GameObjects of "sombras" and hide them
            foreach (Transform child in sombras.transform) {
                child.gameObject.SetActive(false);
            }
        }

        // Function to show freeform shadows
        private void ShowFreeformShadows() {
            // Iterate through child GameObjects of "sombras" and show them
            foreach (Transform child in sombras.transform) {
                child.gameObject.SetActive(true);
            }
        }
    }
}
