using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnItem : MonoBehaviour {

    private string title;
    private string description;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private CanvasGroup c_group;

    public void Initialize(string _title, string _description = "")
    {
        title = _title;
        description = _description;

        titleText.text = title;

        c_group.alpha = 1;
        c_group.interactable = true;
    }

    public void Hide()
    {
        title = "";
        description = "";

        titleText.text = "";

        c_group.alpha = 0;
        c_group.interactable = false;
    }

    void Awake()
    {
        if(titleText.text == "")
        {
            c_group.alpha = 0;
            c_group.interactable = false;
        }
    }

    public void Clicked()
    {

    }

    public void OnHoverEnter()
    {

    }

    public void OnHoverExit()
    {

    }
}
