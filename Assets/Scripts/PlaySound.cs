using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlaySound : MonoBehaviour
{
    private float interval;
    [SerializeField]
    private float intervalMax,intervalMin;
    [SerializeField]
    private AudioClip[] taupeSons, feinteSons;
    bool isTaupe, canActive, isActive;
    [SerializeField]
    private GameObject gameManager;


    [SerializeField] private InputActionReference debugActions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        canActive = true;
        //StartCoroutine(taupeManagement());
        StartCoroutine(taupeStart());
    }

    private void Update()
    {
        if(debugActions.action.IsPressed() && isActive)
        {
            if(isTaupe)
                gameManager.gameObject.GetComponent<GameManager>().addScore();
            else
                gameManager.gameObject.GetComponent<GameManager>().lifeManagement();
            isActive = false;
        }
    }

    private IEnumerator taupeManagement()
    {
        //Il y a 75% de chances que le son soit une taupe
        float rnd = Random.Range(0, 100);
        if (rnd < 75)
            isTaupe = true;
        else
            isTaupe = false;

        if (isTaupe && canActive)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(taupeSons[Random.Range(0, taupeSons.Length)]);
            isActive = true;
            Debug.Log("isTaupe");
        }
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(feinteSons[Random.Range(0, feinteSons.Length)]);
            isActive = true;
            Debug.Log("isFeinte");
        }

        // Interval de temps aleatoire avant le prochain son
        interval = Random.Range(intervalMin, intervalMax);
        Debug.Log("interval = " + interval);
        yield return new WaitForSeconds(interval);
        if (!gameManager.gameObject.GetComponent<GameManager>().getDefeat())
        {
            isActive = false;
            StartCoroutine(taupeManagement());
        }
        
    }

    private IEnumerator taupeStart()
    {
        interval = Random.Range(5, 15);
        yield return new WaitForSeconds(interval);
        StartCoroutine(taupeManagement());
    }
}
