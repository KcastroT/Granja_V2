using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Contador
{
    public class Contadores : MonoBehaviour
    {

        public sistemaMoneda sistemaMoneda;
        public TextMeshProUGUI textoContadorMaiz;
        public TextMeshProUGUI textoContadorTrigo;

        public int contadorMaiz ;
        public int contadorTrigo;

        private void Start()
        {
            IncrementarContadorMaiz();
            IncrementarContadorTrigo();
        }

        public void IncrementarContadorMaiz()
        {
            contadorMaiz++;
            ActualizarTextoContadorMaiz();
            DragMaiz.canDrag = true;

            sistemaMoneda.RestarMonedas(10);
        }

        public void IncrementarContadorTrigo(){
            contadorTrigo++;
            ActualizarTextoContadorTrigo();
            DragTrigo.canDrag = true;

            sistemaMoneda.RestarMonedas(10);
        }
        public void DecrementarContadorMaiz()
        {
            contadorMaiz--;
            if (contadorMaiz <= 0)
            {
                contadorMaiz = 0;
                DragMaiz.canDrag = false;
                DragMaiz.isDragging = false;
            }
            ActualizarTextoContadorMaiz();
        }

        public void DecrementarContadorTrigo()
        {
            contadorTrigo--;
            if (contadorTrigo <= 0)
            {
                contadorTrigo = 0;
                DragTrigo.canDrag = false;
                DragTrigo.isDragging = false;
            }
            ActualizarTextoContadorTrigo();
        }

        private void ActualizarTextoContadorMaiz()
        {
            textoContadorMaiz.text = contadorMaiz.ToString();
        }
        private void ActualizarTextoContadorTrigo()
        {
            textoContadorTrigo.text = contadorTrigo.ToString();
        }

    }
}
