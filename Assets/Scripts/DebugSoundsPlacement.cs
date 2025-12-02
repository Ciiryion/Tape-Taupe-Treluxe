using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugSoundsPlacement : MonoBehaviour
{
    [SerializeField] private InputActionReference debugActions;
    [SerializeField] private AudioSource[] audioSources;
    private bool sequenceOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debugActions.action.Enable();
        sequenceOn = false;
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
            audioSources[i].Play();
            //Debug.Log("Played " + i + " audio source");
            yield return new WaitForSeconds(2);
        }
        sequenceOn = false;
    }
}
