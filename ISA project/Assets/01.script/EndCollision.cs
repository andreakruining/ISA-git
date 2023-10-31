using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("end")) // Replace "Player" with the appropriate tag for your trigger
        {
            StartCoroutine(SwitchSceneAfterDelay());
        }
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
