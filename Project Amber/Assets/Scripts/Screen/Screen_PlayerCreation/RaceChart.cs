using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceChart : MonoBehaviour {

    #region Text Fields
    // Race Modifier
    [SerializeField]
    private Text r_StrText;
    [SerializeField]
    private Text r_DexText;
    [SerializeField]
    private Text r_ConText;
    [SerializeField]
    private Text r_IntText;
    [SerializeField]
    private Text r_WisText;
    [SerializeField]
    private Text r_ChaText;

    // New Score
    [SerializeField]
    private Text ns_StrText;
    [SerializeField]
    private Text ns_DexText;
    [SerializeField]
    private Text ns_ConText;
    [SerializeField]
    private Text ns_IntText;
    [SerializeField]
    private Text ns_WisText;
    [SerializeField]
    private Text ns_ChaText;

    // New Modifier
    [SerializeField]
    private Text nm_StrText;
    [SerializeField]
    private Text nm_DexText;
    [SerializeField]
    private Text nm_ConText;
    [SerializeField]
    private Text nm_IntText;
    [SerializeField]
    private Text nm_WisText;
    [SerializeField]
    private Text nm_ChaText;
    #endregion

    private int r_strMod = 0;
    private int r_dexMod = 0;
    private int r_conMod = 0;
    private int r_intMod = 0;
    private int r_wisMod = 0;
    private int r_chaMod = 0;

    private int strScore = 10;
    private int dexScore = 10;
    private int conScore = 10;
    private int intScore = 10;
    private int wisScore = 10;
    private int chaScore = 10;

    private int new_strScore = 10;
    private int new_dexScore = 10;
    private int new_conScore = 10;
    private int new_intScore = 10;
    private int new_wisScore = 10;
    private int new_chaScore = 10;

    [SerializeField]
    private List<Toggle> abilityToggleList = new List<Toggle>();
    [SerializeField]
    private GameObject abilityTogglesObj;

    public void SetScores(Dictionary<string, int> raceMods)
    {
        r_strMod = 0;
        r_dexMod = 0;
        r_conMod = 0;
        r_intMod = 0;
        r_wisMod = 0;
        r_chaMod = 0;

        strScore = SaveManager.manager.character.str_score;
        dexScore = SaveManager.manager.character.dex_score;
        conScore = SaveManager.manager.character.con_score;
        intScore = SaveManager.manager.character.int_score;
        wisScore = SaveManager.manager.character.wis_score;
        chaScore = SaveManager.manager.character.cha_score;

        new_strScore = strScore;
        new_dexScore = dexScore;
        new_conScore = conScore;
        new_intScore = intScore;
        new_wisScore = wisScore;
        new_chaScore = chaScore;

        ShowAbilityToggles(false);
        foreach (string stri in raceMods.Keys)
        {
            switch(stri)
            {
                case "str":
                    r_strMod = raceMods[stri];
                    break;
                case "dex":
                    r_dexMod = raceMods[stri];
                    break;
                case "con":
                    r_conMod = raceMods[stri];
                    break;
                case "int":
                    r_intMod = raceMods[stri];
                    break;
                case "wis":
                    r_wisMod = raceMods[stri];
                    break;
                case "cha":
                    r_chaMod = raceMods[stri];
                    break;
                case "any":
                    ShowAbilityToggles(true);
                    break;
            }
        }

        UpdateAbilityChart();
    }

    private void UpdateAbilityChart()
    {

        new_strScore += r_strMod;
        new_dexScore += r_dexMod;
        new_conScore += r_conMod;
        new_intScore += r_intMod;
        new_wisScore += r_wisMod;
        new_chaScore += r_chaMod;

        r_StrText.text = Utility.ColorizeText(r_strMod);
        r_DexText.text = Utility.ColorizeText(r_dexMod);
        r_ConText.text = Utility.ColorizeText(r_conMod);
        r_IntText.text = Utility.ColorizeText(r_intMod);
        r_WisText.text = Utility.ColorizeText(r_wisMod);
        r_ChaText.text = Utility.ColorizeText(r_chaMod);

        ns_StrText.text = Utility.ColorizeText(strScore, new_strScore);
        ns_DexText.text = Utility.ColorizeText(dexScore, new_dexScore);
        ns_ConText.text = Utility.ColorizeText(conScore, new_conScore);
        ns_IntText.text = Utility.ColorizeText(intScore, new_intScore);
        ns_WisText.text = Utility.ColorizeText(wisScore, new_wisScore);
        ns_ChaText.text = Utility.ColorizeText(chaScore, new_chaScore);

        nm_StrText.text = Utility.ColorizeText(GetModifier(strScore), GetModifier(new_strScore), true);
        nm_DexText.text = Utility.ColorizeText(GetModifier(dexScore), GetModifier(new_dexScore), true);
        nm_ConText.text = Utility.ColorizeText(GetModifier(conScore), GetModifier(new_conScore), true);
        nm_IntText.text = Utility.ColorizeText(GetModifier(intScore), GetModifier(new_intScore), true);
        nm_WisText.text = Utility.ColorizeText(GetModifier(wisScore), GetModifier(new_wisScore), true);
        nm_ChaText.text = Utility.ColorizeText(GetModifier(chaScore), GetModifier(new_chaScore), true);
    }

    private void ShowAbilityToggles(bool shouldShow)
    {
        abilityTogglesObj.SetActive(shouldShow);
        foreach(Toggle t in abilityToggleList)
        {
            t.isOn = false;
        }
    }

    public void AbilityToggled(Toggle toggle)
    {

        if (!toggle.isOn)
            return;

        foreach (Toggle t in abilityToggleList)
        {
            if (t != toggle)
                t.isOn = false;
        }

        r_strMod = 0;
        r_dexMod = 0;
        r_conMod = 0;
        r_intMod = 0;
        r_wisMod = 0;
        r_chaMod = 0;

        new_strScore = strScore;
        new_dexScore = dexScore;
        new_conScore = conScore;
        new_intScore = intScore;
        new_wisScore = wisScore;
        new_chaScore = chaScore;

        switch (toggle.gameObject.name)
        {
            case "Strength":
                r_strMod += 2;
                break;
            case "Dexterity":
                r_dexMod += 2;
                break;
            case "Constitution":
                r_conMod += 2;
                break;
            case "Intelligence":
                r_intMod += 2;
                break;
            case "Wisdom":
                r_wisMod += 2;
                break;
            case "Charisma":
                r_chaMod += 2;
                break;
        }

        UpdateAbilityChart();
    }

    int GetModifier(int score)
    {
        int modifier = Mathf.FloorToInt(((score - 10.0f) / 2));
        return modifier;
    }
}
