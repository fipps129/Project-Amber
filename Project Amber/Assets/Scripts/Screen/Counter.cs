using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public delegate void OnValueChanged(int num);
    public OnValueChanged valueChanged;

    [SerializeField]
    private Text numberText;
    [SerializeField]
    private int NumberValue = 0;
    [SerializeField]
    private int incrementValue = 1;

    [MinMaxRange(-25, 25)]
    public MinMaxRange range;

    void Start()
    {
        numberText.text = NumberValue.ToString();
    }

    public void SetNumber(int newValue)
    {
        NumberValue = newValue;
        numberText.text = NumberValue.ToString();
       // SetText(NumberValue);
    }

    private void SetText(int num)
    {
        numberText.text = num.ToString();
        if(valueChanged != null)
            valueChanged(num);
    }

    public void IncreaseValue()
    {
        if (NumberValue < range.rangeEnd)
        {
            NumberValue += incrementValue;
            SetText(NumberValue);
        }
    }

    public void DecreaseValue()
    {
        if (NumberValue > range.rangeStart)
        {
            NumberValue -= incrementValue;
            SetText(NumberValue);
        }
    }
}
