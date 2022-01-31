using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausePanel;
    public GameObject deathPanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Pause();
        }
    }

    private void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            AudioListener.pause = false;

        }
    }
    public void EndGame()
    {
        deathPanel.SetActive(true);
        StartCoroutine(WaitAndLoadMenu());
    }
    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");

    }
}
