using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Players;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Puppet : Player
{
    private void Update()
    {
        CheckSkill();
    }

    private void FixedUpdate()
    {
        CheckMoveMent();
    }

    public override void DefaultSkill()
    {
        Debug.Log("used puppet skill");
    }
    public override void AbilitySkill()
    {
        Debug.Log("used puppet skill");
    }
    public override void UltimateSkill()
    {
        Debug.Log("used puppet skill");
    }
    public override void BlockSkill()
    {
        Debug.Log("used puppet skill");
    }
}
