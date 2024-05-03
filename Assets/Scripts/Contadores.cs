/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
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

        public GameObject GameManagerReference;  //recibir booleano del game manager para reiniciar el contadores 

        private string modo = "";

        public int contadorMaiz; //Contador de maiz por poner en el campo
        public int contadorTrigo; //Contador de trigo por poner en el campo
        public int contadorCebada;  //Contador de cebada por poner en el campo
        public int contadorZanahoria; //Contador de zanahoria por poner en el campo

        private int MaizCosechado; //Contador de maiz cosechado
        private int TrigoCosechado; //Contador de trigo cosechado
        private int CebadaCosechado; //Contador de cebada cosechado
        private int ZanahoriaCosechado; //Contador de zanahoria cosechado

        public AudioSource sonidoCompra;
        public AudioSource sonidoDenegado;


        public int precioMaiz = 25;
        public int precioTrigo = 10;
        public int precioCebada = 23;
        public int precioZanahoria = 20;

        public int c = 0;



        private int dineroInicial;
        private int insumos;

        private int Ventas;//Dinero que se obtiene de las ventas

        private float Interes = 0;//Intereses con deuda  de los prestamos 

        private float iverqor = -1.29f;//Interes con deuda de verqor
        private float ibanco = -1.17f;//Interes con deuda de banco
        private float icoyote = -1.37f;//Interes con deuda de coyote

        private float cantidadverqor = 400;//Cantidad de dinero prestado por verqor
        private float cantidadbanco = 350;//Cantidad de dinero prestado por banco
        private float cantidadcoyote = 250;//Cantidad de dinero prestado por coyote

        public TextMeshProUGUI textoModo;
        public TextMeshProUGUI textoDineroPrestamo;
        public TextMeshProUGUI textoInsumos;
        public TextMeshProUGUI textoDineroNoticias;

        public TextMeshProUGUI textoInteres;

        public TextMeshProUGUI textoVentas;

        public TextMeshProUGUI textoBalance;



        //Función que obtiene los valores iniciales de los contadores
        private void Start()
        {
            sonidoCompra = sonidoCompra.GetComponent<AudioSource>();
            sonidoDenegado = sonidoDenegado.GetComponent<AudioSource>();

            dineroInicial = sistemaMoneda.moneda;
            insumos = 0;
            c = 0;
            IncrementarContadorMaiz();
            IncrementarContadorTrigo();
            IncrementarContadorCebada();
            IncrementarContadorZanahoria();
        }

        //Función que actualiza los valores de los contadores
        private void Update()
        {
            GameManager gameManager = GameManager.GetComponent<GameManager>();

            if (gameManager.GameStarted && c == 0)
            {
                if (gameManager.modoDeJuego == "Verqor")
                {
                    Interes = Mathf.FloorToInt(cantidadverqor * iverqor);
                    dineroInicial = Mathf.FloorToInt(cantidadverqor);
                    textoDineroPrestamo.text = dineroInicial.ToString();
                    modo = "Verqor";
                    c++;
                    Debug.Log("Interes verqor: " + Interes);
                }
                else if (gameManager.modoDeJuego == "Tradicional")
                {
                    Interes = Mathf.FloorToInt(cantidadbanco * ibanco);
                    dineroInicial = Mathf.FloorToInt(cantidadbanco);
                    textoDineroPrestamo.text = dineroInicial.ToString();

                    modo = "Banco";
                    c++;
                    Debug.Log("Interes banco: " + Interes);
                }
                else if (gameManager.modoDeJuego == "Coyote")
                {
                    Interes = Mathf.FloorToInt(cantidadcoyote * icoyote);
                    dineroInicial = Mathf.FloorToInt(cantidadcoyote);
                    textoDineroPrestamo.text = dineroInicial.ToString();
                    modo = "Coyote";
                    c++;
                    Debug.Log("Interes coyote: " + Interes);
                }
            }


            //Reiniciar contadores
            if (gameManager.ReiniciarConta == true)
            {
                ReiniciarInventario();
                gameManager.ReiniciarConta = false;
            }

        }

        //Función que reinicia los valores de los contadores
        public void ReiniciarInventario()
        {
            dineroInicial = sistemaMoneda.moneda;
            sistemaMoneda.moneda = 59;//Dinero inicial
            contadorCebada = 0;
            contadorMaiz = 0;
            contadorTrigo = 0;
            contadorZanahoria = 0;
            IncrementarContadorCebada();
            IncrementarContadorMaiz();
            IncrementarContadorTrigo();
            IncrementarContadorZanahoria();
            Ventas = 0;
            insumos = 0;
            MaizCosechado = 0;
            TrigoCosechado = 0;
            CebadaCosechado = 0;
            ZanahoriaCosechado = 0;
            c = 0;
            Interes = 0;
            ActualizarTextoContadorMaiz();
            ActualizarTextoContadorTrigo();
            ActualizarTextoContadorCebada();
            ActualizarTextoContadorZanahoria();

        }


        //Función para incrementar el contador del maíz
        public void IncrementarContadorMaiz()
        {
            if (contadorMaiz < 9)
            {   
                if(c>0){
                sonidoCompra.Play();
                }
                contadorMaiz++;
                ActualizarTextoContadorMaiz();
                DragMaiz.canDrag = true;
                insumos += 20;
                sistemaMoneda.RestarMonedas(20);
            }   
            else
            {
                sonidoDenegado.Play();
            }
        }

        //Función para incrementar el contador de las zanahorias
        public void IncrementarContadorZanahoria()
        {
            if (contadorZanahoria < 9)
            {   
                if(c>0){
                sonidoCompra.Play();
                }

                contadorZanahoria++;
                ActualizarTextoContadorZanahoria();
                DragZanahoria.canDrag = true;
                insumos += 15;
                sistemaMoneda.RestarMonedas(15);
            }else
            {
                sonidoDenegado.Play();
            }
        }

        //Función para incrementar el contador de la cebada
        public void IncrementarContadorCebada()
        {
            if (contadorCebada < 9)
            {
                if(c>0){
                sonidoCompra.Play();
                }
                contadorCebada++;
                ActualizarTextoContadorCebada();
                DragCebada.canDrag = true;
                insumos += 17;

                sistemaMoneda.RestarMonedas(17);
            }else
            {
                sonidoDenegado.Play();
            }
        }

        //Función para incrementar el contador del trigo
        public void IncrementarContadorTrigo()
        {
            if (contadorTrigo < 9)
            {   if(c>0){
                sonidoCompra.Play();
                }
                contadorTrigo++;
                ActualizarTextoContadorTrigo();
                DragTrigo.canDrag = true;
                insumos += 8;

                sistemaMoneda.RestarMonedas(8);
            }else
            {
                sonidoDenegado.Play();
            }
        }

        //Función para vender la cosecha y agregar el dinero a las ventas
        public void VenderCosecha()
        {
            Ventas += (MaizCosechado * precioMaiz) + (TrigoCosechado * precioTrigo) + (CebadaCosechado * precioCebada) + (ZanahoriaCosechado * precioZanahoria);
            textoVentas.text = Ventas.ToString();
            sistemaMoneda.SumarMonedas((MaizCosechado * precioMaiz) + (TrigoCosechado * precioTrigo) + (CebadaCosechado * precioCebada) + (ZanahoriaCosechado * precioZanahoria));
            textoCebadaCosechado.text = CebadaCosechado.ToString();
            textoMaizCosechado.text = MaizCosechado.ToString();
            textoTrigoCosechado.text = TrigoCosechado.ToString();
            textoZanahoriaCosechado.text = ZanahoriaCosechado.ToString();
            textoVentasTemporada.text = ((MaizCosechado * precioMaiz) + (TrigoCosechado * precioTrigo) + (CebadaCosechado * precioCebada) + (ZanahoriaCosechado * precioZanahoria)).ToString();

            MaizCosechado = 0;
            TrigoCosechado = 0;
            CebadaCosechado = 0;
            ZanahoriaCosechado = 0;
        }

        //Función para mostrar la cuenta final del jugador
        public void CuentaFinal()
        {
            textoModo.text = modo;
            textoInsumos.text = insumos.ToString();
            textoDineroNoticias.text = sistemaMoneda.dineroNoticias.ToString();
            textoInteres.text = Interes.ToString();
            textoVentas.text = Ventas.ToString();
            textoBalance.text = sistemaMoneda.moneda.ToString();

            Debug.Log("Modo de juego: " + modo + " Prestamo: " + dineroInicial + " Insumos: " + insumos + " Bono de pregunta" + 0 + " Noticias: " + sistemaMoneda.dineroNoticias + " Intereses: " + Interes + " Ventas: " + Ventas);
        }

        //Función para decrementar el contador del maíz
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

        //Función para decrementar el contador del trigo
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

        //Función para decrementar el contador de la cebada
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

        //Función para decrementar el contador de la zanahoria  
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

        //Funciones para actualizar los textos de los contadores en la UI
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
