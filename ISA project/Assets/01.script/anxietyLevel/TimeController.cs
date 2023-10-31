using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController : MonoBehaviour
{
    //timer
    public GameObject textHolder;
    public Image bar;
    public float maxTime;

    private float timeRemaining;
    private Color noPanicColor = new Color(1f, 1f, 1f); // white
    private Color aThirdPanicColor = new Color(1f, 0.85f, 0.85f); //white/orange
    private Color mildPanicColor = new Color(1f, 0.5f, 0.5f); // orannge
    private Color threeThirdPanicColor = new Color(1f, 0.3f, 0.3f); //red/orange
    private Color fullPanicColor = new Color(1f, 0f, 0f); // red
    public Light sunLight;

    AnxietyScore anxietyScoreScript;

    public AudioSource panicSound;
    public AudioSource MainAudio;

    public bool PanicMode = false;

    private void Start()
    {
        anxietyScoreScript = GetComponent < AnxietyScore >();
        sunLight.color = noPanicColor;
        StartTimer();
        MainAudio.Play();
    }

    private void Update()
    {

        float scaledValue = (timeRemaining - 0.20f) / (maxTime - 0.20f) - 1;

        timeRemaining -= Time.deltaTime;
        bar.fillAmount = timeRemaining / maxTime;

        if (timeRemaining > maxTime / 5 * 4)
        {
            sunLight.color = Color.Lerp(sunLight.color, aThirdPanicColor, -scaledValue);
        }
        else if (timeRemaining < maxTime / 5 * 4 && timeRemaining > maxTime / 5 * 3)
        {
            sunLight.color = Color.Lerp(sunLight.color, mildPanicColor, -scaledValue);
        }
        else if (timeRemaining < maxTime / 5 * 3 && timeRemaining > maxTime / 5 * 2)
        {
            sunLight.color = Color.Lerp(sunLight.color, threeThirdPanicColor, -scaledValue);
        }
        else if (timeRemaining < maxTime / 5 * 2 && timeRemaining > maxTime / 5)
        {
            sunLight.color = Color.Lerp(sunLight.color, fullPanicColor, -scaledValue);
        }
        if (timeRemaining <= 0 && anxietyScoreScript.NoPanic == false)
        {
            textHolder.SetActive(true);
            PanicMode = true;
            MainAudio.Stop();
            playSound();
        }
        Debug.Log(sunLight.color);
       //else if(anxietyScoreScript.NoPanic == true)
       //{
       //    MainAudio.Stop();
       //}
    }

   // IEnumerator ShowMessage()
   // {
   //     textHolder.SetActive(true);
   //     yield return new WaitForSeconds(5);
   //     textHolder.SetActive(false);
   //     StartTimer();
   //     enemyAnxietyScript.enabled = true;
   // }

    void playSound()
    {
        panicSound.Play();
    }

    public void Countdown(float AddTime)
    {
        timeRemaining += AddTime;
    }

    public void StartTimer()
    {
        timeRemaining = maxTime;
        textHolder.SetActive(false);
    }
}
