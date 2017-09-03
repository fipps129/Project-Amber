using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCalculator : MonoBehaviour {

    [SerializeField]
    private Screen_Base AbilityScreen;

    #region Calculator Variables
    [SerializeField]
    private Counter STR_Counter;
    [SerializeField]
    private Counter DEX_Counter;
    [SerializeField]
    private Counter CON_Counter;
    [SerializeField]
    private Counter INT_Counter;
    [SerializeField]
    private Counter WIS_Counter;
    [SerializeField]
    private Counter CHA_Counter;

    [SerializeField]
    private Text str_Mod_Text;
    [SerializeField]
    private Text dex_Mod_Text;
    [SerializeField]
    private Text con_Mod_Text;
    [SerializeField]
    private Text int_Mod_Text;
    [SerializeField]
    private Text wis_Mod_Text;
    [SerializeField]
    private Text cha_Mod_Text;

    private int str_Score = 10;
    private int dex_Score = 10;
    private int con_Score = 10;
    private int int_Score = 10;
    private int wis_Score = 10;
    private int cha_Score = 10;

    private int str_Mod = 0;
    private int dex_Mod = 0;
    private int con_Mod = 0;
    private int int_Mod = 0;
    private int wis_Mod = 0;
    private int cha_Mod = 0;
    #endregion

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private Button lowButton;
    [SerializeField]
    private Button standardButton;
    [SerializeField]
    private Button highButton;
    [SerializeField]
    private Button epicButton;
    [SerializeField]
    private Button manualButton;

    [SerializeField]
    private GameObject ManualBuy;
    [SerializeField]
    private GameObject ScoreBuyers;

    [SerializeField]
    private Text PointText;

    private int TotalPoints = 15;
    private int CurrentPoints = 15;

    void Start()
    {

        str_Score = 10;
        dex_Score = 10;
        con_Score = 10;
        int_Score = 10;
        wis_Score = 10;
        cha_Score = 10;

        STR_Counter.valueChanged = STRChanged;
        DEX_Counter.valueChanged = DEXChanged;
        CON_Counter.valueChanged = CONChanged;
        INT_Counter.valueChanged = INTChanged;
        WIS_Counter.valueChanged = WISChanged;
        CHA_Counter.valueChanged = CHAChanged;

        standardButton.interactable = false;

        CurrentPoints = TotalPoints;
        PointText.text = CurrentPoints.ToString();
    }

    public void ChangeScore(int newScore)
    {
        ResetScores();
        switch (newScore)
        {
            case 10:
                ScoreBuyers.SetActive(true);
                ManualBuy.SetActive(false);
                lowButton.interactable = false;
                standardButton.interactable = true;
                highButton.interactable = true;
                epicButton.interactable = true;
                manualButton.interactable = true;
                TotalPoints = newScore;
                break;
            case 15:
                ScoreBuyers.SetActive(true);
                ManualBuy.SetActive(false);
                lowButton.interactable = true;
                standardButton.interactable = false;
                highButton.interactable = true;
                epicButton.interactable = true;
                manualButton.interactable = true;
                TotalPoints = newScore;
                break;
            case 20:
                ScoreBuyers.SetActive(true);
                ManualBuy.SetActive(false);
                lowButton.interactable = true;
                standardButton.interactable = true;
                highButton.interactable = false;
                epicButton.interactable = true;
                manualButton.interactable = true;
                TotalPoints = newScore;
                break;
            case 25:
                ScoreBuyers.SetActive(true);
                ManualBuy.SetActive(false);
                lowButton.interactable = true;
                standardButton.interactable = true;
                highButton.interactable = true;
                epicButton.interactable = false;
                manualButton.interactable = true;
                TotalPoints = newScore;
                break;
            case 999:
                ScoreBuyers.SetActive(false);
                ManualBuy.SetActive(true);
                lowButton.interactable = true;
                standardButton.interactable = true;
                highButton.interactable = true;
                epicButton.interactable = true;
                manualButton.interactable = false;
                TotalPoints = newScore;
                break;
        }
        PointText.gameObject.SetActive(ScoreBuyers.activeSelf);
        CurrentPoints = newScore;
        PointText.text = CurrentPoints.ToString();
    }

    private void ResetScores()
    {
        STR_Counter.SetNumber(10);
        DEX_Counter.SetNumber(10);
        CON_Counter.SetNumber(10);
        INT_Counter.SetNumber(10);
        WIS_Counter.SetNumber(10);
        CHA_Counter.SetNumber(10);

        str_Mod = 0;
        dex_Mod = 0;
        con_Mod = 0;
        int_Mod = 0;
        wis_Mod = 0;
        cha_Mod = 0;

        str_Mod_Text.text = str_Mod.ToString();
        dex_Mod_Text.text = dex_Mod.ToString();
        con_Mod_Text.text = con_Mod.ToString();
        int_Mod_Text.text = int_Mod.ToString();
        wis_Mod_Text.text = wis_Mod.ToString();
        cha_Mod_Text.text = cha_Mod.ToString();

        descriptionText.text = AbilityStatic.default_desc;
    }

    public void ShowDesc(int num)
    {
        switch (num)
        {
            case 0:
                descriptionText.text = AbilityStatic.str_desc;
                break;
            case 1:
                descriptionText.text = AbilityStatic.dex_desc;
                break;
            case 2:
                descriptionText.text = AbilityStatic.con_desc;
                break;
            case 3:
                descriptionText.text = AbilityStatic.int_desc;
                break;
            case 4:
                descriptionText.text = AbilityStatic.wis_desc;
                break;
            case 5:
                descriptionText.text = AbilityStatic.cha_desc;
                break;
            case 6:
                //descriptionText.text = AbilityStatic.default_desc;
                break;
        }
    }

    #region Ability Listeners
    void STRChanged(int num)
    {
        if (str_Score < num)
            SubtractPoints(num);
        else if (str_Score > num)
            AddPoints(str_Score);
        str_Score = num;
        str_Mod = GetModifier(num);
        str_Mod_Text.text = str_Mod.ToString();
        descriptionText.text = AbilityStatic.str_desc;
    }
    void DEXChanged(int num)
    {
        if (dex_Score < num)
            SubtractPoints(num);
        else if (dex_Score > num)
            AddPoints(dex_Score);
        dex_Score = num;
        dex_Mod = GetModifier(num);
        dex_Mod_Text.text = dex_Mod.ToString();
        descriptionText.text = AbilityStatic.dex_desc;
    }
    void CONChanged(int num)
    {
        if (con_Score < num)
            SubtractPoints(num);
        else if (con_Score > num)
            AddPoints(con_Score);
        con_Score = num;
        con_Mod = GetModifier(num);
        con_Mod_Text.text = con_Mod.ToString();
        descriptionText.text = AbilityStatic.con_desc;
    }
    void INTChanged(int num)
    {
        if (int_Score < num)
            SubtractPoints(num);
        else if (int_Score > num)
            AddPoints(int_Score);
        int_Score = num;
        int_Mod = GetModifier(num);
        int_Mod_Text.text = int_Mod.ToString();
        descriptionText.text = AbilityStatic.int_desc;
    }
    void WISChanged(int num)
    {
        if (wis_Score < num)
            SubtractPoints(num);
        else if (wis_Score > num)
            AddPoints(wis_Score);
        wis_Score = num;
        wis_Mod = GetModifier(num);
        wis_Mod_Text.text = wis_Mod.ToString();
        descriptionText.text = AbilityStatic.wis_desc;
    }
    void CHAChanged(int num)
    {
        if (cha_Score < num)
            SubtractPoints(num);
        else if (cha_Score > num)
            AddPoints(cha_Score);
        cha_Score = num;
        cha_Mod = GetModifier(num);
        cha_Mod_Text.text = cha_Mod.ToString();
        descriptionText.text = AbilityStatic.cha_desc;
    }
    #endregion

    public void ManualChanged(InputField obj)
    {
        if (obj.text == "")
            return;
        switch(obj.gameObject.name)
        {
            case "Strength":
                STRChanged(int.Parse(obj.text));
                break;
            case "Dexterity":
                DEXChanged(int.Parse(obj.text));
                break;
            case "Constitution":
                CONChanged(int.Parse(obj.text));
                break;
            case "Intelligence":
                INTChanged(int.Parse(obj.text));
                break;
            case "Wisdom":
                WISChanged(int.Parse(obj.text));
                break;
            case "Charisma":
                CHAChanged(int.Parse(obj.text));
                break;
        }
    }

    int GetModifier(int score)
    {
        int modifier = Mathf.FloorToInt(((score - 10.0f) / 2));
        return modifier;
    }

    void SubtractPoints(int score)
    {
        if(score<10)
        {
            CurrentPoints -= GetModifier(score) * -1;
        }
        else
        {
            int mod = GetModifier(score);
            if (mod == 0)
                mod = 1;
            CurrentPoints -= mod;
        }
        PointText.text = CurrentPoints.ToString();
    }

    void AddPoints(int score)
    {
        if (score < 10)
        {
            CurrentPoints += GetModifier(score) * -1;
        }
        else
        {
            int mod = GetModifier(score);
            if (mod == 0)
                mod = 1;
            CurrentPoints += mod;
        }
        PointText.text = CurrentPoints.ToString();
    }
 
    public Dictionary<string, List<int>> GetScores()
    {
        Dictionary<string, List<int>> returnList = new Dictionary<string, List<int>>();
        //List<List<int>> returnList = new List<List<int>>();

        List<int> scores = new List<int>();
        List<int> mods = new List<int>();

        // Add Scores
        scores.Add(str_Score);
        scores.Add(dex_Score);
        scores.Add(con_Score);
        scores.Add(int_Score);
        scores.Add(wis_Score);
        scores.Add(cha_Score);

        // Add Modifiers
        mods.Add(str_Mod);
        mods.Add(dex_Mod);
        mods.Add(con_Mod);
        mods.Add(int_Mod);
        mods.Add(wis_Mod);
        mods.Add(cha_Mod);

        returnList.Add("scores", scores);
        returnList.Add("modifiers", mods);

        return returnList;
    }
       
}
