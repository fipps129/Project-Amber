using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class Barbarin : Class {


   // public Dictionary<string, RagePower> RagePowers = new Dictionary<string, RagePower>();

    


    public Barbarin (Class _class)
    {
        
        this.classType = ClassEnum.Barbarian;
        this.description = _class.description;
        this.role = _class.role;
        this.alignment = _class.alignment;
        this.hitDie = _class.hitDie;
        for(int i = 0;i<_class.skills.Count;i++)
        {
            this.skills.Add(_class.skills[i]);
        }
        this.skillRanks = _class.skillRanks;
        for (int i = 0; i < _class.classChart.Count; i++)
        {
            this.classChart.Add(_class.classChart[i]);
        }

        //RagePowers.Add("Mega Strength", MegaStrength);
    }
}
