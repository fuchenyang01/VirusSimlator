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
        npc.GetComponent<Renderer>().material.color = new Color(227f / 255f, 127f / 255f, 0f / 255f);
        npc.name = "E";
        npc.GetComponent<NPC>().RandomMove();
    }

    public override void Reason(GameObject npc)
    {
        if (false)
        {
            fsm.PerformTransition(Transition.PassIncubation);
        }
    }
}
