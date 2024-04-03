using UnityEngine;

public class ControlSembrado : MonoBehaviour
{
    public GameObject clock; // Referencia al GameObject que tiene el componente Timer.
    public int etapa = 0;
    private float etapaTimer = 0f; // Contador para controlar cuándo cambiar de etapa.

    public GameObject tile; // Asumo que este es el GameObject que tiene el componente Tile.
    public GameObject draggedMaiz; // Asumo que este es el GameObject que tiene el componente DragMaiz.

    void Start()
    {
        etapa = 0;
        
    }

    void FixedUpdate()
    {
        // Obtener los componentes de los GameObjects.
        Tile tileComponent = tile.GetComponent<Tile>();
        DragMaiz dragMaizComponent = draggedMaiz.GetComponent<DragMaiz>();

        // Incrementar el contador de etapa.
        etapaTimer += Time.deltaTime;

        // Si el contador alcanza 1 segundo (o más), actualiza la etapa.
        if(etapaTimer >= 1f)
        {   
            //EtapaChanger();
            etapaTimer = 0f; // Restablecer el contador para el próximo segundo.
        }
        // Cambiar la etapa actual cuando 
        if (tileComponent.IsTouched && dragMaizComponent.isDragging)
        {
            etapa = 1;
        }
        

        if (etapa==0)//cuando no hay semillas
        {
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
            
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else
                {

                    child.gameObject.SetActive(false);
                }
            }
        }
        else if (etapa==1){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("a"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==2){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("b"))
                {   
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);

                }else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==3){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("c"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==4){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("d"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==5){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("e"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
    }
    }
    
    void EtapaChanger()
    {
        // Aquí puedes añadir la lógica para cambiar de etapa. 
        // Este ejemplo simplemente incrementa `etapa`.
        etapa++;
        if(etapa >= 5)
        {
            etapa = 0;
        }
        Debug.Log($"Cambio de etapa: {etapa}");
    }
}

