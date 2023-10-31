using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashBackTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlashBackIsOver());
    }

    IEnumerator FlashBackIsOver()
    {
        yield return new WaitForSeconds(30.0f);
        SceneManager.LoadScene("ptsdLevel");        
    }
}
