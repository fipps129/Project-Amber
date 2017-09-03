using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScreen : Screen_Base {

    [SerializeField]
    private ScreenController_Player sc_Player;
    [SerializeField]
    private PointCalculator pointCal;

    public JSONObject obj;

    private List<int> ScoreList = new List<int>();
    private List<int> ModifierList = new List<int>();

    public override void ShowMenu()
    {
        base.ShowMenu();
    }

    public override void HideMenu()
    {
        base.HideMenu();
    }

    public override void NextScreen()
    {
        Dictionary<string, List<int>> retList = new Dictionary<string, List<int>>();
        retList = pointCal.GetScores();
        ScoreList = retList["scores"];
        ModifierList = retList["modifiers"];

        SaveManager.manager.character.str_score = ScoreList[0];
        SaveManager.manager.character.dex_score = ScoreList[1];
        SaveManager.manager.character.con_score = ScoreList[2];
        SaveManager.manager.character.int_score = ScoreList[3];
        SaveManager.manager.character.wis_score = ScoreList[4];
        SaveManager.manager.character.cha_score = ScoreList[5];

        SaveManager.manager.character.str_mod = ModifierList[0];
        SaveManager.manager.character.dex_mod = ModifierList[1];
        SaveManager.manager.character.con_mod = ModifierList[2];
        SaveManager.manager.character.int_mod = ModifierList[3];
        SaveManager.manager.character.wis_mod = ModifierList[4];
        SaveManager.manager.character.cha_mod = ModifierList[5];

        sc_Player.NextPage();
    }

}
