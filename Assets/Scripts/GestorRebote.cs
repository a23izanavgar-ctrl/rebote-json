using System.IO;
using UnityEngine;

public class GestorRebotes : MonoBehaviour
{
    public PelotaRebotando pelota;

    private string carpetaRebotes;
    private string rutaArchivo;

    void Start()
    {
        // Nos aseguramos de que la carpeta de rebotes guardados existe.
        carpetaRebotes = Path.Combine(
            Application.persistentDataPath,
            "RebotesGuardados"
        );

        if (!Directory.Exists(carpetaRebotes))
        {
            Directory.CreateDirectory(carpetaRebotes);
        }

        // Ruta del archivo savedBounces.json
        rutaArchivo = Path.Combine(
            carpetaRebotes,
            "saveRebotes.json"
        );
    }

    public void GuardarRebotes()
    {
        // Generamos una instancia de la clase que guarda
        // la información de los rebotes.
        DatosRebotes datos = new DatosRebotes();

        datos.rebotes = pelota.numeroRebotes;

        // Utilizamos JsonUtility para generar el string JSON.
        string json = JsonUtility.ToJson(datos, true);

        // Generamos el archivo saveRebotes.json
        // con la información del JSON.
        File.WriteAllText(rutaArchivo, json);

        Debug.Log("Rebotes guardados: " + pelota.numeroRebotes);
        Debug.Log("Archivo guardado en: " + rutaArchivo);
    }

    public void CargarRebotes()
    {
        // Nos aseguramos de que la carpeta existe.
        if (!Directory.Exists(carpetaRebotes))
        {
            Debug.Log("La carpeta de rebotes guardados no existe.");
            return;
        }

        // Comprobamos que existe el archivo.
        if (!File.Exists(rutaArchivo))
        {
            Debug.Log("No existe el archivo savedBounces.json.");
            return;
        }

        // Leemos el contenido del archivo.
        string json = File.ReadAllText(rutaArchivo);

        // Generamos una instancia de la clase que guarda
        // la información de los rebotes.
        DatosRebotes datos = new DatosRebotes();

        // Utilizamos JsonUtility para leer el JSON.
        datos = JsonUtility.FromJson<DatosRebotes>(json);

        // Establecemos la información cargada.
        pelota.numeroRebotes = datos.rebotes;

        Debug.Log("Rebotes cargados: " + pelota.numeroRebotes);
    }

    public void SalirJuego()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }

    [System.Serializable]
    private class DatosRebotes
    {
        public int rebotes;
    }
}