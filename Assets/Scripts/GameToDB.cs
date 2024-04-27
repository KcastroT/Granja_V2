using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;



public class GameToDB : MonoBehaviour
{

    public int userID;

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
        public int idPregunta;
        public string contenido;
    }

    struct Answer
    {
        public int pregunta_idpregunta;
        public string contenido;
        public string is_correct;
    }
    //como defino el url como una variable de entorno

    private string url="http://44.222.38.209:8080";





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
        Debug.Log("Response text: " + request.downloadHandler.text);
        //Si la respuesta es exitosa, guarda el nombre de usuario y el ID de usuario 
        //En todas los demas casos o errores marca el mensaje incorrecto
        Debug.Log("Success:" + response.success +
                  "\nInsert ID:" + response.insertId +
                  "\nUserDataManager Instance: " + UserDataManager.Instance);

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

    //se manda hasta el final del juego
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

    
    public IEnumerator UploadQuestion(int _idUsuario, int _idPregunta, string _contenido)
    {
        Question question;
        question.idUsuario = _idUsuario;
        question.idPregunta = _idPregunta;
        question.contenido = _contenido;
        string json = JsonUtility.ToJson(question);

        using (UnityWebRequest www = UnityWebRequest.Post(url+"/preguntas", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    public IEnumerator UploadAnswer(int _pregunta_idpregunta, string _contenido, string _is_correct)
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