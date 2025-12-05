using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int vie, score;
    int minutes, seconds;
    float deltaTimer;
    string niceTime;
    private bool defeat;
    //[SerializeField]
    //GameObject[] sonsPlace;
    [SerializeField]
    AudioClip validSound, wrongSound;
    [SerializeField] TMP_Text scoreTxt, timerTxt, gameOverTxt;
    [SerializeField] Image[] vieTab;
    [SerializeField] GameObject gameOverButton;
    [SerializeField] private InputActionReference debugActions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debugActions.action.Enable();
        vie = 3;
        score = 0;
        defeat = false;
        gameOverTxt.enabled = false;
        gameOverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //debug instant game over
        if (debugActions.action.IsPressed())
        {
            vie = 0;
            defeat=true;
        }

        //Gestion du timer (non fonctionnel)
        deltaTimer += Time.deltaTime;
        minutes = Mathf.FloorToInt(deltaTimer / 60F);
        seconds = Mathf.FloorToInt(deltaTimer - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerTxt.text = niceTime;

        //Affichage du score
        scoreTxt.text = "Score : " + score;

        //Gestion de l'UI des PV
        for (int i = 0; i < vieTab.Length; i++)
        {
            vieTab[i].enabled = false;
        }
        switch (vie)
        {
            case 1:
                for (int i = 0; i < vieTab.Length-2; i++)
                {
                    vieTab[i].enabled = true;
                }
                break;
            case 2:
                for (int i = 0; i < vieTab.Length-1; i++)
                {
                    vieTab[i].enabled = true;
                }
                break;
            case 3:
                for(int i = 0; i < vieTab.Length; i++)
                {
                    vieTab[i].enabled = true;
                }
                break;
        }
        
        if(defeat)
        {
            gameOverButton.SetActive(true);
            gameOverTxt.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void addScore()
    {
        score++;
        gameObject.GetComponent<AudioSource>().PlayOneShot(validSound);
        Debug.Log("score : " + score);
    }

    public void lifeManagement()
    {
        vie--;
        gameObject.GetComponent<AudioSource>().PlayOneShot(wrongSound);
        Debug.Log("nombre de vie : " + vie);
        if (vie <= 0)
        {
            defeat = true;
        }
    }

    public void testButton()
    {
        vie--;
    }

    public bool getDefeat()
    {
        return defeat;
    }
}
