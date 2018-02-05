using System.Collections;
using System.Collections.Generic;

public class RagePower {

    public string r_name;
    public int lvlReq;
    public string description;

    /// <summary>
    /// Is this power only active while in rage
    /// </summary>
    public bool isRage;

    /// <summary>
    /// List of effects that would show up on character sheet
    /// </summary>
    public List<Bonus> bonuses;

    public RagePower(string _powerName, int _levelRequirement, string _description, bool _isRage, List<Bonus> _bonuses)
    {
        r_name = _powerName;
        lvlReq = _levelRequirement;
        description = _description;
        isRage = _isRage;
        bonuses = _bonuses;
    }

}

public class RagePowers
{
   
    public static Dictionary<string, RagePower> AllPowers = new Dictionary<string, RagePower>();

    public static void InitBonuses()
    {
        List<Bonus> mega_bonus = new List<Bonus>();
        Bonus mega_strength = new Bonus("strength", Bonus.BonusType.Morale, 2, "Mega Strength");
        Bonus mega_intelligence = new Bonus("intelligence", Bonus.BonusType.Morale, -2, "Mega Strength");
        mega_bonus.Add(mega_strength);
        mega_bonus.Add(mega_intelligence);

        RagePower megaStrength = new RagePower(
            "Mega Strength",
            1,
            "When Raging, gain an additional +2 strength and -2 intelligence",
            true,
            mega_bonus);
        AllPowers.Add("Mega Strength", megaStrength);


        List<Bonus> supa_bonus = new List<Bonus>();
        Bonus supa_strength = new Bonus("strength", Bonus.BonusType.Morale, -2, "Supa Smart");
        Bonus supa_intelligence = new Bonus("intelligence", Bonus.BonusType.Morale, 2, "Supa Smart");
        supa_bonus.Add(supa_strength);
        supa_bonus.Add(supa_intelligence);

        RagePower supaSmart = new RagePower(
            "Supa Smart",
            2,
            "When Raging, gain an additional +2 intelligence and -2 strength",
            true,
            supa_bonus);
        AllPowers.Add("Supa Smart", supaSmart);

        
    }

}

/*
public class MegaStrength : RagePower{

    private void Awake()
    {
        r_name = "Mega Strength";
        lvlReq = 1;
        description = "When raging, gain an additional +2 to strength";

        isRage = true;

        // i need to create a new Bonus object and add it to the bonuses list
        Bonus strength = new Bonus("strength", Bonus.BonusType.Morale, 2, r_name);
        Bonus intelligence = new Bonus("intelligence", Bonus.BonusType.Morale, -2, r_name);
        bonuses.Add(strength);
        bonuses.Add(intelligence);
    }

}

public class UnhealthyDamage : RagePower
{

    private void Awake()
    {
        r_name = "Unhealthy Damage";
        lvlReq = 2;
        description = "This is where I would change the damage based on characters HP lost";

        isRage = false;
    }

}
*/