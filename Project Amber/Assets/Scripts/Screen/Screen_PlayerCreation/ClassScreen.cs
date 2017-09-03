using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumTypes;

public class ClassScreen : Screen_Base {

    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text skillText;
    [SerializeField]
    private ColumnChart classFeatures;

    [SerializeField]
    private DropdownMenu classDropdown;

    public Dictionary<ClassEnum, Class> classList = new Dictionary<ClassEnum, Class>();
    private ClassEnum currentClass;

    public override void HideMenu()
    {
        base.HideMenu();
    }

    public override void ShowMenu()
    {
        base.ShowMenu();
    }

    public override void NextScreen()
    {
        base.NextScreen();
    }

    public override void LoadScreenData()
    {
        TextAsset textFile = (TextAsset)Resources.Load("JSON_files/classes", typeof(TextAsset));
        JSONObject classObj = new JSONObject(textFile.ToString());

        classDropdown.AddOptions("Core Classes", true);
        int index = 0;
        foreach (JSONObject jObj in classObj.list)
        {

            Class _class = new Class();
            string className = Utility.TrimString(jObj.GetField("title").ToString());
            string classType = Utility.TrimString(jObj.GetField("enum").ToString());

            _class.classType = (ClassEnum)Enum.Parse(typeof(ClassEnum), classType, true);

            _class.description = Utility.TrimString(jObj.GetField("description").ToString());
            _class.role = Utility.TrimString(jObj.GetField("role").ToString());
            _class.alignment = Utility.TrimString(jObj.GetField("alignment").ToString());
            _class.hitDie = Int32.Parse(jObj.GetField("hitdie").ToString());

            foreach (JSONObject skill in jObj.GetField("skills").list)
            {
                Skill sk = new Skill();
                sk.Name = Utility.TrimString(skill.ToString());
                _class.skills.Add(sk);
            }

            _class.skillRanks = Int32.Parse(jObj.GetField("ranks").ToString());

            foreach (JSONObject chartObj in jObj.GetField("chart").list)
            {
                ChartRow row = new ChartRow();
                row.level = Int32.Parse(chartObj.GetField("level").ToString());
                row.bab = Utility.TrimString(chartObj.GetField("bab").ToString());
                row.fort = Int32.Parse(chartObj.GetField("fort").ToString());
                row.reflex = Int32.Parse(chartObj.GetField("fort").ToString());
                row.will = Int32.Parse(chartObj.GetField("fort").ToString());
                foreach (JSONObject spec in chartObj.GetField("special").list)
                {
                    row.specialAbilities.Add(Utility.TrimString(chartObj.GetField("bab").ToString()));
                }
                _class.classChart.Add(row);
            }

            foreach (JSONObject feature in jObj.GetField("features").list)
            {
                DefObj def = new DefObj();
                def.title = Utility.TrimString(feature.GetField("title").ToString());
                def.description = Utility.TrimString(feature.GetField("description").ToString());
                _class.featureDict.Add(def.title, def.description);
            }

            classList.Add(_class.classType, _class);
            classDropdown.AddOptions(className);
            index++;
        }

        classDropdown.SetOptions();

        SetDescriptionText();
        SetSkillText();
        SetClassFeatures();

        //raceChart.SetScores(raceList[currentRace].abilities);
        // SetTraitText(raceList[currentRace].racialTraits);
        // SetDescriptionText();
        // racePortrait.sprite = raceList[currentRace].portrait;
    }

    public void DropdownValueChanged()
    {
        if (classDropdown.IsTitle())
            return;
        currentClass = (ClassEnum)(classDropdown.dropDown.value - 1);
        SetSkillText();
        SetDescriptionText();
        SetClassFeatures();
        //racePortrait.sprite = raceList[currentRace].portrait;
    }

    private void SetDescriptionText()
    {
        string descStr = "";
        descStr += classList[currentClass].description + "\n \n<b>Role</b>:" + classList[currentClass].role;
        descriptionText.text = descStr;
    }

    private void SetSkillText()
    {
        skillText.text = "";
        for (int i=0;i< classList[currentClass].skills.Count;i++)
        {
            skillText.text += classList[currentClass].skills[i].Name + " (" + classList[currentClass].skills[i].ability + ")\n";
        }
    }

    private void SetClassFeatures()
    {
        classFeatures.AddItems(new List<string>(classList[currentClass].featureDict.Keys));
        foreach (string feature in classList[currentClass].featureDict.Keys)
        {
            Debug.Log(feature);
        }
    }
}
