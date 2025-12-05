using System;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ArduinoConnector : MonoBehaviour
{
    public static ArduinoConnector Instance;
    public SerialPort serial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        // Pattern Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Garde cet objet vivant entre les scènes
            OuvrirConnexion();
        }
        else
        {
            // Si un autre ArduinoManager existe déjà (ex: retour au menu), on détruit le nouveau
            Destroy(gameObject);
        }
    }

    void OuvrirConnexion()
    {
        serial = new SerialPort("COM5", 9600); // Remplacez par votre port/baudrate
        try
        {
            serial.Open();
            serial.ReadTimeout = 20;
            // --- AJOUTEZ CES DEUX LIGNES ---
            serial.DtrEnable = true; // Indispensable pour beaucoup d'Arduinos
            serial.RtsEnable = true; // Souvent nécessaire aussi
            // -------------------------------
            Debug.Log("Port ouvert");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erreur port série: " + e.Message);
        }
    }

    // Très important : Fermer le port quand on quitte le jeu
    void OnApplicationQuit()
    {
        if (serial != null && serial.IsOpen)
        {
            serial.Close();
            Debug.Log("Port fermé à la fermeture de l'app");
        }
    }

    // Update is called once per frame
    public string LireDonnees()
    {
        if (serial != null && serial.IsOpen)
        {
            try
            {
                return serial.ReadLine();
            }
            catch (System.TimeoutException)
            {
                return null;
            }
        }
        return null;
    }

    void Update()
    {
        Debug.Log(serial.ReadLine());
    }
}
