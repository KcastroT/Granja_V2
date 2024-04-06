using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime {
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour {
        public float duration = 1f;
        [SerializeField] private Gradient gradient;
        private Light2D _light;
        private float _startTime;
        private bool _running;

        private void Awake() {
            _light = GetComponent<Light2D>();
            _running = false;
        }

        private void Update() {

            if (_running) {
                float timeElapsed = Time.time - _startTime;
                float percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI);
                percentage = Mathf.Clamp01(percentage);
                _light.color = gradient.Evaluate(percentage);
            }
            
        }

        public void StartCycle() {
            _startTime = Time.time;
            _running = true;
        }


    }
}
