using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOption
{
    public string name;
    public System.Action ApplyUpgrade;

    public UpgradeOption(string name, System.Action ApplyUpgrade)
    {
        this.name = name;
        this.ApplyUpgrade = ApplyUpgrade;
    }
}
