using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime {
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour {
        public float duration = 1f;
        [SerializeField] private Gradient gradient;
        private Light2D _light;
        private float _startTime;
        private float percentage;
        private int ciclo;
        [SerializeField] private bool _running;

        private void Awake() {
            _light = GetComponent<Light2D>();
            _running = false;
            ciclo = 0;
        }

        private void Update() {

            if (_running) {
                float timeElapsed = Time.time - _startTime;
                percentage =(Mathf.Sin(2*(timeElapsed / duration * Mathf.PI))/2)+0.5f;
                _light.color = gradient.Evaluate(percentage);
                if (timeElapsed >= 3f) {
                     _running = false; 
                }
            }
            
            
        }

        public void StartCycle() {
            _startTime = Time.time;
            _running = true;

        }


    }
}
