using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC : MonoBehaviour {
    public GameObject plane;
  
    private NavMeshAgent agent;
    public FSMSystem fsm;
    private Vector3 destination;
    private float initSpeed;
    private bool isTouchPatients;
    private float rDay;
    private float eDay;
    private float iDay;

    public bool IsTouchPatients { get => isTouchPatients; set => isTouchPatients = value; }
    public float EDay { get => eDay; set => eDay = value; }
    public float IDay { get => iDay; set => iDay = value; }
    public float RDay { get => rDay; set => rDay = value; }

    // Use this for initialization
    void Awake() {
        rDay = ValueManager.Instance.RDay;
        eDay = ValueManager.Instance.EDay;
        iDay = ValueManager.Instance.IDay;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        initSpeed = agent.speed;
        destination = GenerateRandomPosition(plane.transform.localScale.x, plane.transform.localScale.z) + plane.transform.position;
        agent.SetDestination(destination);
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
        recoveredState.AddTransition(Transition.AntibodyDisappears, StateID.Susceptible);

        fsm.AddState(susceptibleState);
        fsm.AddState(exposedState);
        fsm.AddState(infectiousState);
        fsm.AddState(recoveredState);
    }
	
	// Update is called once per frame
	void Update () {
       
        fsm.Update(this.gameObject);
	}
    public void RandomMove()
    {
        if (Vector3.Distance(this.transform.position, destination) < 0.3f)
        {
            agent.speed = initSpeed;
            destination = GenerateRandomPosition(plane.transform.localScale.x, plane.transform.localScale.z) + plane.transform.position;
            agent.SetDestination(destination);

        }
    }
    Vector3 GenerateRandomPosition(float xScale, float zScale)
    {
        float x = Random.Range(-xScale * 5f, xScale * 5f);
        float z = Random.Range(-zScale * 5f, zScale * 5f);

        return new Vector3(x, 0, z);
    }
    void inf()
    {
        isTouchPatients = true;
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "NPC" && ValueManager.Instance.day > 0) 
        {
            if (fsm.currentStateID == StateID.Infectious)
            {
                float rand = Random.Range(0, 1000);
                if (rand / 1000 < ValueManager.Instance.IinfectRate)
                    collider.gameObject.SendMessage("inf");
            }
            if (fsm.currentStateID == StateID.Exposed)
            {
                float rand = Random.Range(0, 1000);
                if (rand / 1000 < ValueManager.Instance.EinfectRate)
                    collider.gameObject.SendMessage("inf");
            }
        }
    }
}
