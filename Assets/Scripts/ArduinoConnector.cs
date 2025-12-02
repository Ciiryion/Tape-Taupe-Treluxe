using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoConnector : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM5", 115200);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            serial.Open();
            serial.ReadTimeout = 50;

            // --- AJOUTEZ CES DEUX LIGNES ---
            serial.DtrEnable = true; // Indispensable pour beaucoup d'Arduinos
            serial.RtsEnable = true; // Souvent nécessaire aussi
            // -------------------------------

            Debug.Log("Port ouvert. DTR/RTS activés.");
        }
        catch (Exception ex)
        {
            Debug.LogError("Erreur ouverture: " + ex.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            string data = serial.ReadLine();
            Debug.Log("Reçu de l'Arduino: " + data);

            // --- Traitement des données
            if (data.Trim() == "1")
            {
                // Fait quelque chose si le bouton est enfoncé
            }
            else if (data.Trim() == "0")
            {
                // Fait quelque chose si le bouton est relâché
            }
            // --- Fin du Traitement

        }
        catch (TimeoutException)
        {
            // On ignore : l'Arduino n'a pas envoyé de ligne complète dans les 500ms
        }
        catch (Exception ex)
        {
            Debug.LogError("Erreur série inattendue: " + ex.Message);
        }
    }
}
