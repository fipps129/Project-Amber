using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus {

    public string b_name;
    
    public enum BonusType
    {
        Alchemical,
        Armor,
        Base_Attack_Bonus,
        Circumstance,
        Competence,
        Deflection,
        Dodge,
        Enhancement,
        Inherent,
        Insight,
        Luck,
        Morale,
        Natural_Armor,
        Profane,
        Racial,
        Resistance,
        Sacred,
        Shield,
        Size,
        Trait,
        Miscellanious
    }

    public BonusType b_type;

    public int value;
    public string description;

    public Bonus(string _name, BonusType _type, int _value, string _description)
    {
        b_name = _name;
        b_type = _type;
        value = _value;
        description = _description;
    }
}
