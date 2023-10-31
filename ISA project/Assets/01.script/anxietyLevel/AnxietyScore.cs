using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnxietyScore : MonoBehaviour
{
    int maxBreathScore = 5;
    public static int breathValue;

    public static bool panic;

    TimeController timeControllerScript;

    [SerializeField]
    private GameObject congratsText;

    public bool NoPanic = false;


    // Start is called before the first frame update
    void Start()
    {
        congratsText.SetActive(false);
        breathValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (breathValue == maxBreathScore && timeControllerScript.PanicMode == false)
        {
            congratsText.SetActive(true);
            NoPanic = true;
            StartCoroutine(SwitchSceneAfterDelay());
        }
    }

    public void AddScore(int newScore)
    {
        breathValue += newScore;
    }

    public void PanicMode()
    {
        //add to score
        //unhide when all breaths are found
        //doorToContinue.SetActive(false);
        //and all enemies are gone and all is relief

        //if not all breaths are found within time
        //then panic attack, all is scary, lost
        //end of panic attac; game over: try this situation again in shame or continue like it never happened
        //panic = true;
    }

    IEnumerator SwitchSceneAfterDelay()
    {
        // Wait for a short delay (adjust the duration as needed)
        yield return new WaitForSeconds(1.0f); // You can adjust the delay time as needed

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int randomSceneIndex;

        do
        {
            randomSceneIndex = Random.Range(1, 4); // Generates 1, 2, or 3
        } while (randomSceneIndex == currentSceneIndex);

        // Load the randomly selected scene
        SceneManager.LoadScene(randomSceneIndex);
        Debug.Log(randomSceneIndex);
    }

}
