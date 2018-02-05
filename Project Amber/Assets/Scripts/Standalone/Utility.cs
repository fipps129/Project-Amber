using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class Utility
{ 

    public static string TrimString(string input)
    {
        string output;
        input = input.TrimEnd(new Char[] { '"' });
        output = input.TrimStart(new Char[] { '"' });
        return output;
    }

    public static string ColorizeText(int num)
    {
        TextColor color = TextColor.Black;
        string plusStr = "";
        if (num < 0)
        {
            color = TextColor.Red;
        }
        else if (num > 0)
        {
            color = TextColor.Green;
            plusStr = "+";
        }

        return "<color=" + color.ToString() + ">" + plusStr + num + "</color>";
    }

    public static string ColorizeText(string text, TextColor color)
    {
        return "<color=" + color.ToString() + ">" + text + "</color>";
    }

    public static string ColorizeText(int originalNumber, int newNumber, bool addPlus = false)
    {
        TextColor color = TextColor.Black;
        string plusStrOne = "";
        string plusStrTwo = "";

        if (addPlus)
        {
            if (originalNumber > 0)
                plusStrOne = "+";
            if (newNumber > 0)
                plusStrTwo = "+";
        }

        if (originalNumber < newNumber)
        {
            color = TextColor.Green;
        }
        else if (originalNumber > newNumber)
        {
            color = TextColor.Red;
        }
        else
        {
            return (plusStrTwo + newNumber.ToString());
        }


        return "<color=" + color.ToString() + ">" + plusStrTwo + newNumber.ToString() + "</color>(" + plusStrOne + originalNumber.ToString() + ")";
    }

    public static string AbilityShort(AbilityEnum ability)
    {
        switch(ability)
        {
            case AbilityEnum.Strength:
                return "STR";
            case AbilityEnum.Dexterity:
                return "DEX";
            case AbilityEnum.Constitution:
                return "CON";
            case AbilityEnum.Intelligence:
                return "INT";
            case AbilityEnum.Wisdom:
                return "WIS";
            case AbilityEnum.Charisma:
                return "CHA";
            default:
                return "ERROR";
        }
    }
}


[Serializable]
public class GenericDictionary<key, value>
{
    public List<key> keys;
    public List<value> values;

    public void Add(key _key, value _value)
    {
        keys.Add(_key);
        values.Add(_value);
    }

    /// <summary>
    /// Get value by key
    /// </summary>
    /// <param name="_key"></param>
    /// <returns></returns>
    public value GetValue(key _key)
    {
        if(this.keys.Contains(_key))
        {
            int index = this.keys.IndexOf(_key);
            return values[index];
        }
        else
        {
            return default(value);
        }
    }

    /// <summary>
    /// Get value at index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public value GetValue(int index)
    {
        if (this.values.Count<index)
        {
            return values[index];
        }
        else
        {
            return default(value);
        }
    }
}

[Serializable]
public class SerDictionary : GenericDictionary<string, GameObject>
{
    
}