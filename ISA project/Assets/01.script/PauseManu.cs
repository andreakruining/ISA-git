using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseManu : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseMenuUI;

    public GameObject pressQ;

    //public GameObject introduction;

    private void Start()
    {
        Invoke("PressQToPause", 5f);
        //introduction.SetActive(true);
        //Time.timeScale = 0f;
        //Debug.Log(introduction);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsGamePaused)
            {
                Resume();
            } else
            {
                Pausing();
            }
        }
    }

    //IEnumerator PressQToPause()
    //{
    //    pressQ.SetActive(true);
    //    yield return new WaitForSeconds(5);
    //    pressQ.SetActive(false);
    //}

    //public void EndIntroduction()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        introduction.SetActive(false);
    //        Invoke("PressQToPause", 5f);
    //        Time.timeScale = 1f;
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;
    //    }
    //}

    void PressQToPause()
    {
        pressQ.SetActive(false);
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pausing()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeButton()
    {
        Resume();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("OpeningMenu");
    }
}
