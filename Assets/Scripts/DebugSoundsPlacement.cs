using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugSoundsPlacement : MonoBehaviour
{
    [SerializeField] private InputActionReference debugActions;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private GameObject[] testPanels;
    private bool sequenceOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debugActions.action.Enable();
        sequenceOn = false;
        for (int i = 0; i < testPanels.Length; i++)
        {
            Debug.Log("desactiver " + i);
            testPanels[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (debugActions.action.IsPressed() && !sequenceOn)
        {
            sequenceOn = true;
            StartCoroutine(DebugSequence());
        }
        else if (sequenceOn)
        {
            Debug.Log("Debug déjà en cours");
        }
    }

    IEnumerator DebugSequence()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            testPanels[i].SetActive(true);
            audioSources[i].Play();
            //Debug.Log("Played " + i + " audio source");
            yield return new WaitForSeconds(2);
            testPanels[i].SetActive(false);
        }
        sequenceOn = false;
    }
}
