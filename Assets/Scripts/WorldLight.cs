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
        [SerializeField]public bool  running;

        private void Awake() {
            _light = GetComponent<Light2D>();
            running = false;

        }

        private void Update() {

            if (running) {
                float timeElapsed = Time.time - _startTime;
                percentage =(Mathf.Sin(2*(timeElapsed / duration * Mathf.PI))/2)+0.5f;
                _light.color = gradient.Evaluate(percentage);
                if (timeElapsed >= 3f) {
                     running = false; 
                }
            }
            
            
        }

        public void StartCycle() {
            _startTime = Time.time;
            running = true;

        }


    }
}
