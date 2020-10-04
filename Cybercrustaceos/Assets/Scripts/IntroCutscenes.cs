using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutscenes : MonoBehaviour
{
    public float fade = 1.0f;
    public float duration = 2.0f;
    float fadeTimer;
    float timer;
    int current = 0;
    public CanvasGroup logo;
    public CanvasGroup cut1;
    public CanvasGroup cut2;
    public CanvasGroup cut3;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        timer = 0;
        fadeTimer = 0;
        logo.alpha = 1;
        cut1.alpha = 0;
        cut2.alpha = 0;
        cut3.alpha = 0;
    }

    private void Update()
    {
        if (!Input.anyKey)
        {
            if (current == 0)
            {
                FadeImages(logo, cut1);
            }
            else if (current == 1)
            {
                FadeImages(cut1, cut2);
            }
            else if (current == 2)
            {
                FadeImages(cut2, cut3);
            }
            else if (timer > duration)
            {
                SceneManager.LoadScene(sceneName: "Tutorial");
            }

            timer += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(sceneName: "Tutorial");
        }
    }

    void FadeImages(CanvasGroup before, CanvasGroup after)
    {
        if (timer > duration)
        {
            if (fadeTimer < fade)
            {
                after.alpha = fadeTimer / fade;
                before.alpha = (1 - fadeTimer) / fade;
                fadeTimer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                fadeTimer = 0;
                current++;
            }
        }
    }
}
