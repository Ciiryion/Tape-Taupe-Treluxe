using System;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    ArduinoConnector arduinoManager;
    String arduinoData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       arduinoManager = gameManager.GetComponent<ArduinoConnector>();
    }

    // Update is called once per frame
    void Update()
    {
        arduinoData = arduinoManager.data;  
        Debug.Log(arduinoData);
    }
}
