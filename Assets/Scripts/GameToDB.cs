/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


//Define una clase para enviar datos a la base de datos en comunicación con la API
public class GameToDB : MonoBehaviour
{

    public int userID;
    public int questID;

    //Estructuras para guardar los datos de usuario, juego, pregunta y respuesta
    struct User
    {
        public string nombre;
        public string apellido;
        public string correo;
        public string contrasena;
        public string anio_nacimiento;
        public string genero;
    }

    struct Game
    {
        public int idUsuario;
        public string financiamiento;
        public int puntaje;
    }

    struct Question
    {
        public int idUsuario;
        public string contenido;
    }

    struct Answer
    {
        public int pregunta_idpregunta;
        public string contenido;
        public bool is_correct;
    }


    //URL de la API
    private string url="http://35.169.14.147:8080";




    //Funcion para subir un usuario a la base de datos
    public IEnumerator UploadUser(string _nombre, string _apellido, string _correo, string _contrasena, string _anio_nacimiento, string _genero)
    {
    User user;
    user.nombre = _nombre;
    user.apellido = _apellido;
    user.correo = _correo;
    user.contrasena = _contrasena;
    user.anio_nacimiento = _anio_nacimiento;
    user.genero = _genero;
    string json = JsonUtility.ToJson(user);

    Debug.Log(json);
    
    UnityWebRequest request = UnityWebRequest.Post(url+"/usuarios", json, "application/json");
    yield return request.SendWebRequest();

    //Procesa la respuesta del servidor
    if (request.result == UnityWebRequest.Result.Success) {
    try {
        ApiResponse response = JsonUtility.FromJson<ApiResponse>(request.downloadHandler.text);

        if (response.success) {
            UserDataManager.Instance = new UserDataManager();
            UserDataManager.Instance.IDUsuario = response.insertId.ToString();
            UserDataManager.Instance.NombreUsuario = user.nombre;
            UserDataManager.Instance.ApellidoUsuario = user.apellido;
            UserDataManager.Instance.AñoNacimientoUsuario = user.anio_nacimiento;
            UserDataManager.Instance.EmailUsuario = user.correo;
            UserDataManager.Instance.GeneroUsuario = user.genero;
            
            userID = response.insertId;

            Debug.Log("Usuario registrado con ID: " + response.insertId);
        } else {
            Debug.LogError("Error en la API: " + response.error);
        }
    } catch (System.Exception ex) {
        Debug.LogError("Error al procesar la respuesta: " + ex.Message);
    }

    }
    
    }

    //Funcion para subir un juego a la base de datos
    public IEnumerator UploadGame(int _idUsuario, string _financiamiento, int _puntaje)
    {
        Game game;
        game.idUsuario = _idUsuario;
        game.financiamiento = _financiamiento;
        game.puntaje = _puntaje;
        string json = JsonUtility.ToJson(game);

        using (UnityWebRequest www = UnityWebRequest.Post(url+"/partidas", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    //Funcion para subir una pregunta a la base de datos
    public IEnumerator UploadQuestion(int _idUsuario, string _contenido)
    {
        Question question;
        question.idUsuario = _idUsuario;
        question.contenido = _contenido;
        string json = JsonUtility.ToJson(question);

        UnityWebRequest request = UnityWebRequest.Post(url+"/preguntas", json, "application/json");
        yield return request.SendWebRequest();

        //Procesa la respuesta del servidor
        if (request.result == UnityWebRequest.Result.Success) {
        try {
            ApiResponse response = JsonUtility.FromJson<ApiResponse>(request.downloadHandler.text);
            Debug.Log("Response text: " + request.downloadHandler.text);
            //Si la respuesta es exitosa, guarda el nombre de usuario y el ID de usuario 
            //En todas los demas casos o errores marca el mensaje incorrecto
            Debug.Log("Success Pregunta:" + response.success +
                    "\n Preguntaaaa ID:" + response.insertId);

            if (response.success) {

                questID = response.insertId;
                Debug.Log("Pregunta registrado con ID: " + response.insertId +
                        "Para usuario: " + UserDataManager.Instance.IDUsuario);
            } else {
                Debug.LogError("Error en la API: " + response.error);
            }
        } catch (System.Exception ex) {
            Debug.LogError("Error al procesar la respuesta: " + ex.Message);
        }

        }
    }

    //Funcion para subir una respuesta a la base de datos
    public IEnumerator UploadAnswer(int _pregunta_idpregunta, string _contenido, bool _is_correct)
    {
        Answer answer;
        answer.pregunta_idpregunta = _pregunta_idpregunta;
        answer.contenido = _contenido;
        answer.is_correct = _is_correct;
        string json = JsonUtility.ToJson(answer);

        using (UnityWebRequest www = UnityWebRequest.Post(url+"/respuestas", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    //Función para manejar la respuesta del servidor
    void HandleResponse(UnityWebRequest www)
    {
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    [System.Serializable] //Clase para recibir la respuesta del servidor
    public class ApiResponse {
    public bool success;
    public int insertId;
    public string error;
    }
}