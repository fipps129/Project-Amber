using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class Skill  {

    private string name;

    public string Name
    {
        get
        {

            return this.name;
        }
        set
        {
            this.name = value;

            TextAsset textFile = (TextAsset)Resources.Load("JSON_files/skills", typeof(TextAsset));
            JSONObject skillObj = new JSONObject(textFile.ToString());

            foreach (JSONObject jObj in skillObj.list)
            {
                if (value == Utility.TrimString(jObj.GetField("title").ToString()))
                {
                    ability = (AbilityEnum)Enum.Parse(typeof(AbilityEnum), Utility.TrimString(jObj.GetField("ability").ToString()), true);
                    untrained = Boolean.Parse(jObj.GetField("untrained").ToString());
                    description = Utility.TrimString(jObj.GetField("description").ToString());
                }
            }

        }
    }

    public AbilityEnum ability;

    public string description;

    public bool untrained;
}
