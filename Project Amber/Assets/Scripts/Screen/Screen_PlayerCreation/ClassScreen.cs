using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumTypes;

public class ClassScreen : Screen_Base {

    public ClassChartController ClassChart;

    [SerializeField]
    private ScreenController_Player sc_Player;

    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private ColumnChart skillChart;
    [SerializeField]
    private ColumnChart classFeatures;

    [SerializeField]
    private DropdownMenu classDropdown;

    public Dictionary<ClassEnum, JSONObject> classObjDict = new Dictionary<ClassEnum, JSONObject>();
    public Dictionary<ClassEnum, Class> classList = new Dictionary<ClassEnum, Class>();
    private ClassEnum currentClass;

    private Dictionary<ClassEnum, Sprite> portraitDict = new Dictionary<ClassEnum, Sprite>();

    [SerializeField]
    private Image classPortrait;

    [SerializeField]
    public SerDictionary classOptionsDictionary = new SerDictionary();

    private Character character;

    private GameObject classOptionsObj;

    [SerializeField]
    private Popup_Base popup;

    [SerializeField]
    private Text addOptButton;

    [SerializeField]
    private Text addOptButtonTwo;

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

    public override void PreviousScreen()
    {
        popup.ClosePopup();
        sc_Player.PrevousPage();
    }

    public override void LoadScreenData()
    {
        character = SaveManager.manager.character;

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
            classObjDict.Add(_class.classType, jObj);   // Saves the json object to get extra data when they select class

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
                row.reflex = Int32.Parse(chartObj.GetField("ref").ToString());
                row.will = Int32.Parse(chartObj.GetField("will").ToString());
                foreach (JSONObject spec in chartObj.GetField("special").list)
                {
                    row.specialAbilities.Add(Utility.TrimString(spec.ToString()));
                }
                _class.classChart.Add(row);
            }

            foreach (JSONObject feature in jObj.GetField("features").list)
            {
                /*
                DefObj def = new DefObj();
                def.title = Utility.TrimString(feature.GetField("title").ToString());
                def.description = Utility.TrimString(feature.GetField("description").ToString());
                */
                string f_title = Utility.TrimString(feature.GetField("title").ToString());
                string f_description = Utility.TrimString(feature.GetField("description").ToString());
                _class.featureDict.Add(f_title, f_description);
            }

            classList.Add(_class.classType, _class);
            classDropdown.AddOptions(className);
            index++;
        }
        classDropdown.SetOptions();
    }

    public override void LoadScreen()
    {
        portraitDict.Clear();

        foreach(ClassEnum _class in classList.Keys)
        {
            portraitDict.Add(_class, (Sprite)Resources.Load(("Sprites/Class_Portraits/" + character.race.raceType.ToString() + "_classes/" + character.race.raceType.ToString() + "_" + _class.ToString()), typeof(Sprite)));
        }


        SetDescriptionText();
        SetSkillText();
        SetClassFeatures();
        SetPortrait();
    }

    public void DropdownValueChanged()
    {
        popup.ClosePopup();

        if (classDropdown.IsTitle())
            return;
        currentClass = (ClassEnum)(classDropdown.dropDown.value - 1);
        SetSkillText();
        SetDescriptionText();
        SetClassFeatures();
        SetPortrait();
    }

    private void SetDescriptionText()
    {
        string descStr = "";
        descStr += classList[currentClass].description + "\n \n<b>Role</b>:" + classList[currentClass].role;
        descriptionText.text = descStr;
    }

    private void SetSkillText()
    {
        skillChart.Reset();
        List<string> skillStrings = new List<string>();
        foreach(Skill skill in classList[currentClass].skills)
        {
            skillStrings.Add((skill.Name + " ("+ Utility.AbilityShort(skill.ability) + ")"));
        }
        skillChart.AddItems(skillStrings);
    }

    private void SetClassFeatures()
    {
        classFeatures.Reset();
        classFeatures.AddItems(new List<string>(classList[currentClass].featureDict.Keys));
        foreach (string feature in classList[currentClass].featureDict.Keys)
        {
            //Debug.Log(feature);
        }
    }

    private void SetPortrait()
    {
        classPortrait.sprite = portraitDict[classList[currentClass].classType];
    }
    
    private void SetAddOptButtonText()
    {
        switch(currentClass)
        {
            case ClassEnum.Barbarian:
                addOptButton.text = "Rage Powers";
                addOptButtonTwo.text = "";
                break;
            case ClassEnum.Bard:
                break;
            case ClassEnum.Cleric:
                break;
            case ClassEnum.Druid:
                break;
            case ClassEnum.Fighter:
                break;
            case ClassEnum.Monk:
                break;
            case ClassEnum.Paladin:
                break;
            case ClassEnum.Ranger:
                break;
            case ClassEnum.Rogue:
                break;
            case ClassEnum.Sorcerer:
                break;
            case ClassEnum.Wizard:
                break;
        }
    }

    public void ClassOptionsPressed()
    {
        popup.ClosePopup(); 
         classOptionsObj = GameObject.Instantiate(classOptionsDictionary.GetValue(currentClass.ToString()), this.transform, false) as GameObject;
    }

    public void ShowAbilityPopup(Text abilityText)
    {
        string descText = classList[currentClass].featureDict[abilityText.text];
        popup.ShowPopup(abilityText.text, descText);
    }

    public void ShowAbilityPopup(String abilityText)
    {
        string descText = classList[currentClass].featureDict[abilityText];
        popup.ShowPopup(abilityText, descText);
    }

    public void ShowSkillPopup(Text skillText)
    {
        string skillName = skillText.text.Substring(0, skillText.text.Length - 6);
        Skill sk = classList[currentClass].skills.Find(item => item.Name == skillName);

        string descText = sk.description;
        popup.ShowPopup(skillText.text, descText);
    }

    public void ShowClassChart()
    {
        ClassChart.ShowClassChart();
    }

    public Class GetCurrentClass()
    {
        return classList[currentClass];
    }

}
