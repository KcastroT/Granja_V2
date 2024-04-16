using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Contador
{
    public class Contadores : MonoBehaviour
    {

        public sistemaMoneda sistemaMoneda;
        public TextMeshProUGUI textoContadorMaiz;
        public TextMeshProUGUI textoContadorTrigo;
        public TextMeshProUGUI textoContadorCebada;
        public TextMeshProUGUI textoContadorZanahoria;

        public int contadorMaiz ;
        public int contadorTrigo;
        public int contadorCebada;
        public int contadorZanahoria;

        private void Start()
        {
            IncrementarContadorMaiz();
            IncrementarContadorTrigo();
            IncrementarContadorCebada();
            IncrementarContadorZanahoria();
        }

        public void IncrementarContadorMaiz()
        {
            contadorMaiz++;
            ActualizarTextoContadorMaiz();
            DragMaiz.canDrag = true;

            sistemaMoneda.RestarMonedas(10);
        }

        public void IncrementarContadorZanahoria()
        {
            contadorZanahoria++;
            ActualizarTextoContadorZanahoria();
            DragZanahoria.canDrag = true;

            sistemaMoneda.RestarMonedas(10);
        }
        public void IncrementarContadorCebada()
        {
            contadorCebada++;
            ActualizarTextoContadorCebada();
            DragCebada.canDrag = true;

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

        public void DecrementarContadorZanahoria()
        {
            contadorZanahoria--;
            if (contadorZanahoria <= 0)
            {
                contadorZanahoria = 0;
                DragZanahoria.canDrag = false;
                DragZanahoria.isDragging = false;
            }
            ActualizarTextoContadorZanahoria();
        }
        public void DecrementarContadorCebada()
        {
            contadorCebada--;
            if (contadorCebada <= 0)
            {
                contadorCebada = 0;
                DragCebada.canDrag = false;
                DragCebada.isDragging = false;
            }
            ActualizarTextoContadorCebada();
        }

        private void ActualizarTextoContadorMaiz()
        {
            textoContadorMaiz.text = contadorMaiz.ToString();
        }
        private void ActualizarTextoContadorTrigo()
        {
            textoContadorTrigo.text = contadorTrigo.ToString();
        }
        private void ActualizarTextoContadorCebada()
        {
            textoContadorCebada.text = contadorCebada.ToString();
        }
        private void ActualizarTextoContadorZanahoria()
        {
            textoContadorZanahoria.text = contadorZanahoria.ToString();
        }
    }
}
