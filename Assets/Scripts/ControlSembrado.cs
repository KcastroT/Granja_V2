/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using UnityEngine;
using Unity;
using Contador;
using System.Collections;

namespace WorldTime {
    // La clase ControlSembrado gestiona las etapas de crecimiento de un cultivo en un entorno de simulación.
    public class ControlSembrado : MonoBehaviour
    {
        public GameObject clock; // Referencia al GameObject que contiene el componente Timer.
        public GameObject RebootEtapa;

        public int etapa = 0; // Indica la etapa actual de crecimiento del cultivo.
        private float etapaTimer = 0f; // Cronómetro para medir el tiempo transcurrido en la etapa actual.

        private float tiempoCambioEtapa = 0.5f; // Intervalo de tiempo antes de pasar a la siguiente etapa.

        private bool sembrado; // Estado que indica si el cultivo ha sido sembrado.

        private int cocktador = 0; // Contador para controlar la reproducción de sonido una sola vez.

        public GameObject light; // GameObject que contiene el componente WorldLight.
        public GameObject tile; // GameObject que contiene el componente Tile.
        public GameObject draggedMaiz; // GameObject que contiene el componente DragMaiz.
        public GameObject PlantingCrop; // GameObject que se asume contiene el componente de audio para el sonido de plantación.

        void Start()
        {
            etapa = 0;
            sembrado = false;
            cocktador = 0;
        }

        void Update()
        {
            // Obtener componentes necesarios de los GameObjects.
            Tile tileComponent = tile.GetComponent<Tile>();
            DragMaiz dragMaizComponent = draggedMaiz.GetComponent<DragMaiz>();
            WorldLight worldLightComponent = light.GetComponent<WorldLight>();
            RebootEtapa rebootEtapaComponent = RebootEtapa.GetComponent<RebootEtapa>();

            // Incrementar el contador de tiempo para cambiar de etapa.
            etapaTimer += Time.deltaTime;

            // Restablecer la etapa si se solicita un reinicio.
            if (rebootEtapaComponent.reboot)
            {
                etapa = 0;
                sembrado = false;
                cocktador = 0;
            }

            // Avanzar a la siguiente etapa si las condiciones lo permiten.
            if (sembrado && worldLightComponent.running && etapa != 0) {
                if (etapaTimer >= tiempoCambioEtapa) {
                    etapaTimer = 0f; 
                    etapa++;
                    if (etapa >= 5) {
                        etapa = 5; // Limitar la etapa máxima a 5
                    }
                }
            }

            // Manejo de la plantación y activación de objetos en función de la etapa.
            if (tileComponent.IsTouched && DragMaiz.isDragging && !sembrado)
            {
                etapa = 1;
                GameObject.FindAnyObjectByType<Contadores>().DecrementarContadorMaiz();
            }

            // Actualizar la visibilidad de objetos hijo en función de la etapa actual.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.name == "lit")
                {
                    continue; // Ignorar el hijo "lit".
                }
                else
                {
                    bool shouldActivate = (etapa > 0) && (child.name.Contains(((char)('a' + etapa - 1)).ToString()));
                    child.gameObject.SetActive(shouldActivate);
                }
            }

            // Reproducir sonido durante la primera plantación.
            sound();
        }

        // Función para reproducir el sonido de sembrado una sola vez.
        void sound()
        {
            if (cocktador == 0)
            {
                cocktador++;
                PlantingCrop.GetComponent<AudioSource>().Play();
            }
        }
    }
}
