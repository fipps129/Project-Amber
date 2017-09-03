using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour {

    public Dropdown dropDown;
    private List<bool> isTitleList = new List<bool>();
    private List<Dropdown.OptionData> optionData = new List<Dropdown.OptionData>();

    public void AddOptions(string text, bool isTitle = false)
    {
        optionData.Add(new Dropdown.OptionData(text));
        isTitleList.Add(isTitle);
    }

    public void AddOptions(Sprite image, bool isTitle = false)
    {
        optionData.Add(new Dropdown.OptionData(image));
        isTitleList.Add(isTitle);
    }

    public void AddOptions(string text, Sprite image, bool isTitle = false)
    {
        optionData.Add(new Dropdown.OptionData(text, image));
        isTitleList.Add(isTitle);
    }

    public void SetOptions()
    {
        dropDown.options.Clear();
        dropDown.options = optionData;
        dropDown.value = 1;
    }

    public bool IsTitle()
    {
        return isTitleList[dropDown.value];
    }

    public bool IsTitle(Text label)
    {
        foreach(Dropdown.OptionData od in optionData)
        {
            if(od.text == label.text)
            {
                return (isTitleList[optionData.IndexOf(od)]);
            }
        }
        return false;
    }

    public void LeftPressed()
    {
        do
        {
            if (dropDown.value != 0)
            {
                dropDown.value -= 1;
            }
            else
            {
                dropDown.value = dropDown.options.Count - 1;
            }
        } while (isTitleList[dropDown.value]);
    }
    public void RightPressed()
    {
         do
        {
            if (dropDown.value != dropDown.options.Count-1)
            {
                dropDown.value += 1;
            }
            else
            {
                dropDown.value = 0;
            }
        } while (isTitleList[dropDown.value]);
    }
}
