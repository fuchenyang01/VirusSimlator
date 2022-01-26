﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveredState : FSMState
{

    public RecoveredState(FSMSystem fsm) : base(fsm)
    {
        stateID = StateID.Recovered;
    }

    public override void Act(GameObject npc)
    {
        npc.GetComponent<Renderer>().material.color = new Color(0 / 255f, 149f / 255f, 226f / 255f);
        npc.name = "R";
        //随机移动
        npc.GetComponent<NPC>().RandomMove();
    }

    public override void Reason(GameObject npc)
    {
    }
}