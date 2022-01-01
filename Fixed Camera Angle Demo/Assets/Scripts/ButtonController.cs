using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;

        pausePanel = GameObject.Find("Pause Menu");
        pausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseResumeGame();
        }
    }

    public void PauseResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            isPaused = !isPaused;
            pausePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
