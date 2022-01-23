using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusceptibleState : FSMState
{

    public SusceptibleState(FSMSystem fsm) : base(fsm)
    {
        stateID = StateID.Susceptible;
    }

    public override void Act(GameObject npc)
    {
       //随机移动
    }

    public override void Reason(GameObject npc)
    {
        //接触患者
        if (true)
        {
            fsm.PerformTransition(Transition.TouchPatients);
        }      
    }
}
