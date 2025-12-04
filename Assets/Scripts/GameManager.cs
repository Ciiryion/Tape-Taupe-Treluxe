using TMPro;
using UnityEngine;
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
    [SerializeField] TMP_Text scoreTxt, timerTxt;
    [SerializeField] Image[] vieTab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vie = 3;
        score = 0;
        defeat = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion du timer (non fonctionnel)
        deltaTimer += Time.deltaTime;
        minutes = Mathf.FloorToInt(Time.deltaTime / 60F);
        seconds = Mathf.FloorToInt(Time.deltaTime - minutes * 60);
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
            Debug.Log("C'est perdu");
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

    public bool getDefeat()
    {
        return defeat;
    }
}
