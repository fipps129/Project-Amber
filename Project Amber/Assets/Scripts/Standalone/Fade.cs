using UnityEngine;
using System.Collections;



public class Fade : MonoBehaviour
{
    private FadeController.OnFadeCallback onfadeCallback;

    private CanvasGroup c_group;
    private float time = 0.0f;
    private bool startFadeIn = false;
    private bool startFadeOut = false;

    void Awake()
    {
        c_group = this.GetComponent<CanvasGroup>();
    }

    public void FadeIn(float _time, FadeController.OnFadeCallback _fadeCallback)
    {
        time = _time;
        onfadeCallback = _fadeCallback;
        startFadeIn = true;
    }

    public void FadeOut(float _time, FadeController.OnFadeCallback _fadeCallback)
    {
        time = _time;
        onfadeCallback = _fadeCallback;
        startFadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFadeIn)
        {
            startFadeOut = false;
            c_group.alpha += (Time.deltaTime / time);
            if (c_group.alpha >= 1)
            {
                startFadeIn = false;
                c_group.interactable = true;
                c_group.blocksRaycasts = true;

                if (onfadeCallback != null)
                    onfadeCallback();
            }
        }

        if (startFadeOut)
        {
            startFadeIn = false;
            c_group.alpha -= (Time.deltaTime / time);
            if (c_group.alpha <= 0)
            {
                startFadeOut = false;
                c_group.interactable = false;
                c_group.blocksRaycasts = false;

                if (onfadeCallback != null)
                    onfadeCallback();
            }
        }
    }
}

public class FadeController
{

    public delegate void OnFadeCallback();

    public static void SetAlphaOne(GameObject gameObject)
    {
        CanvasGroup c_group = gameObject.GetComponent<CanvasGroup>();
        if (c_group == null)
            c_group = gameObject.AddComponent<CanvasGroup>();

        c_group.alpha = 1.0f;
    }

    public static void SetAlphaZero(GameObject gameObject)
    {
        CanvasGroup c_group = gameObject.GetComponent<CanvasGroup>();
        if (c_group == null)
            c_group = gameObject.AddComponent<CanvasGroup>();

        c_group.alpha = 0.0f;
    }

    public static void FadeObjectIn(GameObject gameObject, float time)
    {
        FadeObjectIn(gameObject, time, null);
    }

    public static void FadeObjectOut(GameObject gameObject, float time)
    {
        FadeObjectOut(gameObject, time, null);
    }

    public static void FadeObjectIn(GameObject gameObject, float time, OnFadeCallback _fadeCallback)
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();

        Fade fade;

        if (gameObject.GetComponent<Fade>() != null)
        {
            fade = gameObject.GetComponent<Fade>();
        }
        else
        {
            fade = gameObject.AddComponent<Fade>();
        }

        fade.FadeIn(time, _fadeCallback);
    }

    public static void FadeObjectOut(GameObject gameObject, float time, OnFadeCallback _fadeCallback)
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();

        Fade fade;

        if (gameObject.GetComponent<Fade>() != null)
        {
            fade = gameObject.GetComponent<Fade>();
        }
        else
        {
            fade = gameObject.AddComponent<Fade>();
        }
        fade.FadeOut(time, _fadeCallback);
    }

}