using System;
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
        //随机移动
    }

    public override void Reason(GameObject npc)
    {
    }
}