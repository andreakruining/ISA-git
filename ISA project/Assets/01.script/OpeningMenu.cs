using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningMenu : MonoBehaviour
{
    public GameObject chooseLevel;

    private void Start()
    {
        chooseLevel.SetActive(false);
    }
    public void StartGame()
    {
        chooseLevel.SetActive(true);
    }

    public void AnxietyLevel()
    {
        SceneManager.LoadScene("AnxietyLevel");
    }

    public void DepressionLevel()
    {
        SceneManager.LoadScene("DepressionLevel");
    }

    public void ptsdlevel()
    {
        SceneManager.LoadScene("ptsdLevel");
    }

    public void BackSpace()
    {
        chooseLevel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
