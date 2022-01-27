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
        if (npc.GetComponent<NPC>().EDay != -1)
        {
            npc.GetComponent<NPC>().EDay -= Time.deltaTime;
            if (npc.GetComponent<NPC>().EDay <= 0)
            {
                ValueManager.Instance.ENum--;
                ValueManager.Instance.INum++;
                fsm.PerformTransition(Transition.PassIncubation);
            }
        } 
    }
}
