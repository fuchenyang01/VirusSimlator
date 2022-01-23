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

    }

    public override void Reason(GameObject npc)
    {
        if (true)
        {
            fsm.PerformTransition(Transition.EndQuarantine);
        }
    }
}

