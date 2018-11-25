using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumTypes;

public class RaceScreen : Screen_Base {

    [SerializeField]
    private ScreenController_Player sc_Player;

    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text traitsText;
    [SerializeField]
    private RaceChart raceChart;
    [SerializeField]
    private Image racePortrait;
    [SerializeField]
    private List<Sprite> portraits = new List<Sprite>();

    [SerializeField]
    private DropdownMenu raceDropdown;

    public Dictionary<RaceEnum, Race> raceList = new Dictionary<RaceEnum, Race>();
    private RaceEnum currentRace;

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
        SaveManager.manager.character.race = raceList[currentRace];
        SaveManager.manager.SaveCharacter();

        sc_Player.NextPage();
    }

    public override void PreviousScreen()
    {
        sc_Player.PrevousPage();
    }

    public override void LoadScreenData()
    {
        // Testing this here 11/16/18
        RagePowers.InitBonuses();

        TextAsset textFile = (TextAsset)Resources.Load("JSON_files/races", typeof(TextAsset));// (TextAsset)Resources.Load("races.json"), typeof(TextAsset));
        JSONObject raceObj = new JSONObject(textFile.ToString());

        raceDropdown.AddOptions("Core Races", true);
        int index = 0;
        foreach (JSONObject jObj in raceObj.list)
        {

            Race race = new Race();
            string raceName = Utility.TrimString(jObj.GetField("title").ToString());
            string raceType = Utility.TrimString(jObj.GetField("enum").ToString());

            race.raceType = (RaceEnum)Enum.Parse(typeof(RaceEnum), raceType, true);
            foreach (JSONObject ability in jObj.GetField("Abilities").list)
            {
                string key = Utility.TrimString(ability.GetField("title").ToString());
                int value = Int32.Parse(ability.GetField("value").ToString());
                race.abilities.Add(key, value);
            }
            foreach (JSONObject trait in jObj.GetField("Traits").list)
            {
                Trait newTrait = new Trait();
                newTrait.name = Utility.TrimString(trait.GetField("title").ToString());
                newTrait.description = Utility.TrimString(trait.GetField("description").ToString());
                race.racialTraits.Add(newTrait);
            }

            race.description = Utility.TrimString(jObj.GetField("description").ToString());
            race.physicalDescription = Utility.TrimString(jObj.GetField("physical_description").ToString());

            race.portrait = portraits[index];

            raceList.Add(race.raceType, race);
            raceDropdown.AddOptions(raceName);
            index++;
        }
        raceDropdown.SetOptions();
    }

    public override void LoadScreen()
    {
        raceChart.SetScores(raceList[currentRace].abilities);
        SetTraitText(raceList[currentRace].racialTraits);
        SetDescriptionText();
        racePortrait.sprite = raceList[currentRace].portrait;
    }

    public void DropdownValueChanged()
    {
        if (raceDropdown.IsTitle())
            return;
        currentRace = (RaceEnum)(raceDropdown.dropDown.value-1);
        raceChart.SetScores(raceList[currentRace].abilities);
        SetTraitText(raceList[currentRace].racialTraits);
        SetDescriptionText();
        racePortrait.sprite = raceList[currentRace].portrait;
    }

    private void SetTraitText(List<Trait> traitList)
    {
        string traitStr = "";
        foreach(Trait trait in traitList)
        {
            traitStr += "<b>" + trait.name + "</b>: " + trait.description + "\n";
        }
        traitsText.text = traitStr;
    }

    private void SetDescriptionText()
    {
        string descStr = "";
        descStr += raceList[currentRace].description + "\n \n<b>Physical Description</b>:" + raceList[currentRace].physicalDescription;
        descriptionText.text = descStr;
    }
}
