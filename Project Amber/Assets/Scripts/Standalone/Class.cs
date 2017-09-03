using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class Class {

    public ClassEnum classType;

    public string description;

    public string role;

    public string alignment;

    public int hitDie;

    public List<Skill> skills = new List<Skill>();

    public int skillRanks;

    public List<ChartRow> classChart = new List<ChartRow>();

   //public List<DefObj> featureList = new List<DefObj>();
    public Dictionary<string, string> featureDict = new Dictionary<string, string>();
}
