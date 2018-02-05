using EnumTypes;

public class Character {

    public string name;
    public string player_name;

    // Public Ability Scores
    public int str_score = 10;
    public int dex_score = 10;
    public int con_score = 10;
    public int int_score = 10;
    public int wis_score = 10;
    public int cha_score = 10;

    // Public Ability Modifiers
    public int str_mod = 0;
    public int dex_mod = 0;
    public int con_mod = 0;
    public int int_mod = 0;
    public int wis_mod = 0;
    public int cha_mod = 0;

    public Race race = new Race();
}
