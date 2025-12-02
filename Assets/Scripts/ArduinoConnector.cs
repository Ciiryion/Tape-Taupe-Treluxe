using UnityEngine;
using System.IO.Ports;

public class ArduinoConnector : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM3", 9600);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
