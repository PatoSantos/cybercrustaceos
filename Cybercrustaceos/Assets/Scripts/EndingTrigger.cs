using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    bool startEnding = false;
    bool musicTransition = true;
    public float fade = 1.0f;
    public float duration = 2.0f;
    float fadeTimer;
    float timer;
    float firstTimer;
    int current = 0;
    public CanvasGroup cut4;
    public CanvasGroup cut5;
    public CanvasGroup cut6;
    public CanvasGroup cut7;

    public GameObject BGMusic;
    public GameObject tension;
    private AudioSource BGAudio;
    private AudioSource tensionAudio;

    public GameObject possessionObj;
    private Possession possession;

    // Start is called before the first frame update
    void Start()
    {
        BGAudio = BGMusic.GetComponent<AudioSource>();
        tensionAudio = tension.GetComponent<AudioSource>();
        possession = possessionObj.GetComponent<Possession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startEnding && firstTimer > duration)
        {
            if (timer < duration && musicTransition)
            {
                BGAudio.volume = (1 - timer) / duration;
                tensionAudio.volume = (timer / duration)*0.6f;
            } else
            {
                musicTransition = false;
            }
            cut4.alpha = 1;
            if (current == 0)
            {
                FadeImages(cut4, cut5);
            }
            else if (current == 1)
            {
                FadeImages(cut5, cut6);
            }
            else if (current == 2)
            {
                FadeImages(cut6, cut7);
            }
            else if (timer > duration)
            {
                Application.Quit();
            }

            timer += Time.deltaTime;
        }
        firstTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MarcoController marco = other.gameObject.GetComponent<MarcoController>();
        Animator animator = other.gameObject.GetComponent<Animator>();

        if(marco != null)
        {
            possession.mainChar = false;
            marco.transform.position += new Vector3(0.7f, 0.0f, 0.0f);
            animator.SetBool("Crouch", true);
            animator.SetFloat("Direction", 1.0f);
            animator.SetFloat("Speed", 0.0f);
            startEnding = true;
            firstTimer = 0;
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
