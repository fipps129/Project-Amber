using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager manager;

    public Character character;

    JSONObject saveObj = new JSONObject(JSONObject.Type.OBJECT);
    JSONObject abilityAr = new JSONObject(JSONObject.Type.ARRAY);

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        manager = this;
    }

    public void CreateNewCharacter()
    {
        character = new Character();
        character.name = "Mival";
    }

    public void CreateSaveObject()
    {
        saveObj.AddField("name", character.name);
        saveObj.AddField("playerName", character.player_name);

        saveObj.AddField("abilities", abilityAr);
        abilityAr.Add(character.str_score);
        abilityAr.Add(character.dex_score);
        abilityAr.Add(character.con_score);
        abilityAr.Add(character.int_score);
        abilityAr.Add(character.wis_score);
        abilityAr.Add(character.cha_score);

        saveObj.AddField("race", character.race.raceType.ToString());
    }

    public void SaveCharacter()
    {
        CreateSaveObject();
        string path = "Assets/Resources/" + character.name + ".json";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(saveObj.ToString());
        writer.Close();

    }







}


