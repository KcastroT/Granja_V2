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
        public int contadorMaiz = 0;

        public void IncrementarContadorMaiz()
        {
            contadorMaiz++;
            ActualizarTextoContadorMaiz();
            DragMaiz.canDrag = true;

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

        private void ActualizarTextoContadorMaiz()
        {
            textoContadorMaiz.text = contadorMaiz.ToString();
        }

    }
}
