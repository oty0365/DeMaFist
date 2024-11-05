using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Players;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Puppet : Player
{
    private void Start()
    {
        SetUpPlayer();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AirBone(3,2,-1);
        }
        CheckFloor();
        CheckSkill();
    }

    private void FixedUpdate()
    {
        CheckMovement();
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
