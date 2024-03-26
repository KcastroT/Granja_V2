using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime {
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour {
        public float duration = 5f;
        [SerializeField] private Gradient gradient;
        private Light2D _light;
        private float _startTime;

        private void Awake() {
            _light = GetComponent<Light2D>();
            _startTime = Time.time;
        }

        private void Update() {
            float timeElapsed = Time.time - _startTime;
            float percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI);
            percentage = Mathf.Clamp01(percentage);

            _light.color = gradient.Evaluate(percentage);
        }
    }
}
