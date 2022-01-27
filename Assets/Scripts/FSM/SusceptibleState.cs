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
        npc.GetComponent<Renderer>().material.color =new Color(0, 159f/255f, 11f/ 255f);
        npc.name = "S";
        //随机移动
        npc.GetComponent<NPC>().RandomMove();

    }

    public override void Reason(GameObject npc)
    {
        //接触患者
        if (false)
        {
            ValueManager.Instance.SNum--;
            ValueManager.Instance.ENum++;
            fsm.PerformTransition(Transition.TouchPatients);
        }      
    }
}
