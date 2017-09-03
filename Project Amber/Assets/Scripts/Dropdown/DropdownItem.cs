using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownItem : MonoBehaviour {

    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Text label;
    [SerializeField]
    private DropdownMenu dropDownMenu;

    public void Start()
    {
        toggle.interactable = !dropDownMenu.IsTitle(label);
    }

	public void SetTitle()
    {
        //toggle.interactable = isTitle;
    }


}
