using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

namespace Contador
{
    public class Contadores : MonoBehaviour
    {
        
        public GameObject GameManager;//game manager para saber en que financiamiento estamos
        public sistemaMoneda sistemaMoneda; //Dinero
        public TextMeshProUGUI textoContadorMaiz;
        public TextMeshProUGUI textoContadorTrigo;
        public TextMeshProUGUI textoContadorCebada;
        public TextMeshProUGUI textoContadorZanahoria;

        public TextMeshProUGUI textoMaizCosechado;
        public TextMeshProUGUI textoTrigoCosechado;
        public TextMeshProUGUI textoCebadaCosechado;
        public TextMeshProUGUI textoZanahoriaCosechado;
        public TextMeshProUGUI textoVentasTemporada;

        public int contadorMaiz ; //Contador de maiz por poner en el campo
        public int contadorTrigo; //Contador de trigo por poner en el campo
        public int contadorCebada;  //Contador de cebada por poner en el campo
        public int contadorZanahoria; //Contador de zanahoria por poner en el campo

        private int MaizCosechado; //Contador de maiz cosechado
        private int TrigoCosechado; //Contador de trigo cosechado
        private int CebadaCosechado; //Contador de cebada cosechado
        private int ZanahoriaCosechado; //Contador de zanahoria cosechado

        public int precioMaiz = 25;
        public int precioTrigo = 15;
        public int precioCebada = 40;
        public int precioZanahoria = 35;

        public int c=0;



        private int  dineroInicial;
        private int insumos;

        private int Ventas;//Dinero que se obtiene de las ventas

        private float Interes;//Intereses con deuda  de los prestamos 

        private float iverqor=-1.29f;//Interes con deuda de verqor
        private float ibanco=-1.17f;//Interes con deuda de banco
        private float icoyote=-1.37f;//Interes con deuda de coyote

        private float cantidadverqor=400;//Cantidad de dinero prestado por verqor
        private float cantidadbanco=350;//Cantidad de dinero prestado por banco
        private float cantidadcoyote=250;//Cantidad de dinero prestado por coyote






        private void Start()
        {   
            dineroInicial = sistemaMoneda.moneda;
            insumos = 0;


            

            
            IncrementarContadorMaiz();
            IncrementarContadorTrigo();
            IncrementarContadorCebada();
            IncrementarContadorZanahoria();
        }

        private void Update()
        {
            GameManager gameManager = GameManager.GetComponent<GameManager>();

            if(gameManager.GameStarted && c<=0){
                if(gameManager.modoDeJuego=="Verqor"){
                    Interes = cantidadverqor*iverqor;
                    c++;
                    Debug.Log("Interes verqor: "+Interes);
                }else if(gameManager.modoDeJuego=="Banco"){
                    Interes = cantidadbanco*ibanco;
                    c++;
                    Debug.Log("Interes banco: "+Interes);
                }else if(gameManager.modoDeJuego=="Coyote"){
                    Interes = cantidadcoyote*icoyote;
                    c++;
                    Debug.Log("Interes coyote: "+Interes);
                }
            }
        }

        public void IncrementarContadorMaiz()
        {
            contadorMaiz++;
            ActualizarTextoContadorMaiz();
            DragMaiz.canDrag = true;
            insumos += 10;
            sistemaMoneda.RestarMonedas(10);
        }

        public void IncrementarContadorZanahoria()
        {
            contadorZanahoria++;
            ActualizarTextoContadorZanahoria();
            DragZanahoria.canDrag = true;
            insumos += 20;
            sistemaMoneda.RestarMonedas(20);
        }
        public void IncrementarContadorCebada()
        {
            contadorCebada++;
            ActualizarTextoContadorCebada();
            DragCebada.canDrag = true;
            insumos += 15;

            sistemaMoneda.RestarMonedas(15);
        }

        public void IncrementarContadorTrigo(){
            contadorTrigo++;
            ActualizarTextoContadorTrigo();
            DragTrigo.canDrag = true;
            insumos += 5;

            sistemaMoneda.RestarMonedas(5);
        }


        public void VenderCosecha()
        {
            Ventas += MaizCosechado*precioMaiz + TrigoCosechado*precioTrigo + CebadaCosechado*precioCebada + ZanahoriaCosechado*precioZanahoria;
            sistemaMoneda.SumarMonedas((MaizCosechado*precioMaiz + TrigoCosechado*precioTrigo + CebadaCosechado*precioCebada + ZanahoriaCosechado*precioZanahoria));
            textoCebadaCosechado.text = CebadaCosechado.ToString();
            textoMaizCosechado.text = MaizCosechado.ToString();
            textoTrigoCosechado.text = TrigoCosechado.ToString();
            textoZanahoriaCosechado.text = ZanahoriaCosechado.ToString();
            textoVentasTemporada.text = (MaizCosechado*precioMaiz + TrigoCosechado*precioTrigo + CebadaCosechado*precioCebada + ZanahoriaCosechado*precioZanahoria).ToString();
            
            MaizCosechado = 0;
            TrigoCosechado = 0;
            CebadaCosechado = 0;
            ZanahoriaCosechado = 0;
        }


        public void DecrementarContadorMaiz()
        {
            contadorMaiz--;
            MaizCosechado++;
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
            TrigoCosechado++;
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
            ZanahoriaCosechado++;
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
            CebadaCosechado++;
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
