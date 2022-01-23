using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposedState : FSMState
{

    public ExposedState(FSMSystem fsm) : base(fsm)
    {
        stateID = StateID.Exposed;
   
    }


    public override void Act(GameObject npc)
    {

    }

    public override void Reason(GameObject npc)
    {
        if (true)
        {
            fsm.PerformTransition(Transition.PassIncubation);
        }
    }
}
