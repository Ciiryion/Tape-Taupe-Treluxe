using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int vie, score;
    private bool defeat;
    //[SerializeField]
    //GameObject[] sonsPlace;
    [SerializeField]
    AudioClip validSound, wrongSound;

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
