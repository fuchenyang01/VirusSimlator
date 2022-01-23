using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    private FSMSystem fsm;

	// Use this for initialization
	void Start () {
        InitFSM();
	}

    void InitFSM()
    {
        fsm = new FSMSystem();

        FSMState susceptibleState = new SusceptibleState(fsm);
        susceptibleState.AddTransition(Transition.TouchPatients, StateID.Exposed);

        FSMState exposedState = new ExposedState(fsm);
        exposedState.AddTransition(Transition.PassIncubation, StateID.Infectious);

        FSMState infectiousState = new InfectiousState(fsm);
        infectiousState.AddTransition(Transition.EndQuarantine, StateID.Recovered);

        FSMState recoveredState = new RecoveredState(fsm);

        fsm.AddState(susceptibleState);
        fsm.AddState(exposedState);
        fsm.AddState(infectiousState);
        fsm.AddState(recoveredState);
    }
	
	// Update is called once per frame
	void Update () {
        fsm.Update(this.gameObject);
	}
}
