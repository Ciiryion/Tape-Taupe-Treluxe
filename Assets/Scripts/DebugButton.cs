using System;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] private AudioSource[] audioSources;
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
        arduinoData = ArduinoConnector.Instance.LireDonnees();
        if (new string(arduinoData[11],1) == "1")
        {
            audioSources[0].Play();
        }
        if(new string(arduinoData[27], 1) == "1")
        {
            audioSources[1].Play();
        }
        if (new string(arduinoData[43], 1) == "1")
        {
            audioSources[2].Play();
        }
        if (new string(arduinoData[60], 1) == "1")
        {
            audioSources[3].Play();
        }
        if (new string(arduinoData[77], 1) == "1")
        {
            audioSources[4].Play();
        }
        Debug.Log(arduinoData);
    }
}
