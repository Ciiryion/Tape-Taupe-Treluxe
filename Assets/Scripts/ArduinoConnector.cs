using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoConnector : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM5", 9600);
    public string data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            serial.Open();
            serial.ReadTimeout = 20;

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
            data = serial.ReadLine();
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

    public String getArduinoData()
    {
        return data;
    }
}
