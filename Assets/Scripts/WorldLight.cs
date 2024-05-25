
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime {
    [RequireComponent(typeof(Light2D))]

    //Clase para cambiar la luz del mundo
    public class WorldLight : MonoBehaviour {
        public float duration = 1f;
        [SerializeField] private Gradient gradient;
        private Color showShadowColor; 
        private Light2D _light;
        private float _startTime;
        private float percentage;
        [SerializeField] public bool running;

        private GameObject sombras; 

        private void Awake() {
            _light = GetComponent<Light2D>();
            sombras = GameObject.Find("sombras"); 
            running = false;
        }

        // Función que se encarga de cambiar el color de la luz del mundo
        private void Update() {
            if (running) {
                float timeElapsed = Time.time - _startTime;
                percentage = (Mathf.Sin(2 * (timeElapsed / duration * Mathf.PI)) / 2) + 0.5f;
                _light.color = gradient.Evaluate(percentage);


                Color targetColor = HexToColor("F8D858");
                float tolerance = 0.2f; 


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

        //Función para iniciar el ciclo de la luz
        public void StartCycle() {
            _startTime = Time.time;
            running = true;
        }


        private Color HexToColor(string hex) {
            Color color;
            if (ColorUtility.TryParseHtmlString("#" + hex, out color)) {
                return color;
            } else {
                Debug.LogError("Color hexadecimal inválido: " + hex);
                return Color.white; 
            }
        }

       
        private bool IsColorInRange(Color color, Color targetColor, float tolerance) {

            float rDiff = Mathf.Abs(color.r - targetColor.r);
            float gDiff = Mathf.Abs(color.g - targetColor.g);
            float bDiff = Mathf.Abs(color.b - targetColor.b);


            return rDiff <= tolerance && gDiff <= tolerance && bDiff <= tolerance;
        }


        private void HideFreeformShadows() {

            foreach (Transform child in sombras.transform) {
                child.gameObject.SetActive(false);
            }
        }


        private void ShowFreeformShadows() {

            foreach (Transform child in sombras.transform) {
                child.gameObject.SetActive(true);
            }
        }
    }
}
