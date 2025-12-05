using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] InputActionReference pauseAction;
    bool pause;

    private void Start()
    {
        pauseAction.action.Enable();
        pause = false;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (pauseAction.action.IsPressed())
        {
            Debug.Log("Pause");
            pauseManagment();
        }
    }

    public void pauseManagment()
    {
        if (pause)
        {
            depause();
        }
        else
        {
            putOnPause();
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    private void putOnPause()
    {
        pause = true;
        Debug.Log("Menu pause");
        pauseMenu.SetActive(pause);
        Time.timeScale = 0;
    }
    private void depause()
    {
        pause = false;
        Debug.Log("Menu depause");
        pauseMenu.SetActive(pause);
        Time.timeScale = 1;
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
