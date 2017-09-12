using System;
using System.Collections;
using System.Collections.Generic;
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
                break;
            case AbilityEnum.Dexterity:
                return "DEX";
                break;
            case AbilityEnum.Constitution:
                return "CON";
                break;
            case AbilityEnum.Intelligence:
                return "INT";
                break;
            case AbilityEnum.Wisdom:
                return "WIS";
                break;
            case AbilityEnum.Charisma:
                return "CHA";
                break;
            default:
                return "ERROR";
        }
    }
}