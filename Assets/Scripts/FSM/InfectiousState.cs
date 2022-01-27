using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectiousState : FSMState
{

    public InfectiousState(FSMSystem fsm) : base(fsm)
    {
        stateID = StateID.Infectious;

    }


    public override void Act(GameObject npc)
    {
        npc.GetComponent<Renderer>().material.color = Color.red;
        npc.name = "I";
        npc.GetComponent<NPC>().RandomMove();
    }

    public override void Reason(GameObject npc)
    {
        if (false)
        {
            ValueManager.Instance.INum--;
            ValueManager.Instance.RNum++;
            fsm.PerformTransition(Transition.EndQuarantine);
        }
    }
}

