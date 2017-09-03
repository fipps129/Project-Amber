using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class Race {

    public RaceEnum raceType;

    public Dictionary<string, int> abilities = new Dictionary<string, int>();

    public SizeEnum size;

    public string description;

    public string physicalDescription;

    public Dictionary<string, string> speedDesc = new Dictionary<string, string>();

    public int speed;

    public List<Trait> racialTraits = new List<Trait>();

    public List<string> languages = new List<string>(); // This will most definitely turn in to a list of enums

    public Sprite portrait;

}

public class Trait
{
    public string name;
    public string description;
}

