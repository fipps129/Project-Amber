using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_Base : MonoBehaviour {

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    [SerializeField]
    private ScrollRect descScroll;

    void Start()
    {
        FadeController.FadeObjectOut(this.gameObject, 0.5f);
    }

    public void ShowPopup()
    {
        descScroll.verticalNormalizedPosition = 1.0f;
        title.text = "Error";
        description.text = "Something went wrong";
        FadeController.FadeObjectIn(this.gameObject, 0.5f);
    }

    public void ShowPopup(string _title, string _description)
    {
        descScroll.verticalNormalizedPosition = 1.0f;
        title.text = _title;
        description.text = _description;
        FadeController.FadeObjectIn(this.gameObject, 0.5f);
    }

    public void ClosePopup()
    {
        FadeController.FadeObjectOut(this.gameObject, 0.5f);
    }


}
