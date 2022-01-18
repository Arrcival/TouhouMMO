using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatutable
{
    public float HPBonus { get; set; }
    public float ManaBonus { get; set; }
    public float AtkBonus { get; set; }
    public float AtkBonusPercentage { get; set; }
    public float PowBonusPercentage { get; set; }
    public float DefBonus { get; set; }
    public float CritBonus { get; set; }
    public float CritDmgBonus { get; set; }
    public float RegenBonus { get; set; }

}
