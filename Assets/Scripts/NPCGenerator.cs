using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public GameObject NPC;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        ValueManager.Instance.day = -3;
        timer = ValueManager.Instance.secForDay;

        for (int i = 0; i < ValueManager.Instance.SNum; i++)
        {
            GameObject SNPC = Instantiate(NPC, this.transform.position, this.transform.rotation);
            SNPC.transform.parent = this.transform;
            SNPC.name = "S";
            SNPC.GetComponent<NPC>().fsm.SetState(StateID.Susceptible);
        }

        for (int i = 0; i < ValueManager.Instance.ENum; i++)
        {
            GameObject ENPC = Instantiate(NPC, this.transform.position, this.transform.rotation);
            ENPC.transform.parent = this.transform;
            ENPC.name = "E";
            ENPC.GetComponent<NPC>().fsm.SetState(StateID.Exposed);
        }

        for (int i = 0; i < ValueManager.Instance.INum; i++)
        {
            GameObject INPC = Instantiate(NPC, this.transform.position, this.transform.rotation);
            INPC.transform.parent = this.transform;
            INPC.name = "I";
            INPC.GetComponent<NPC>().fsm.SetState(StateID.Infectious);
        }

        for (int i = 0; i < ValueManager.Instance.RNum; i++)
        {
            GameObject RNPC = Instantiate(NPC, this.transform.position, this.transform.rotation);
            RNPC.transform.parent = this.transform;
            RNPC.name = "R";
            RNPC.GetComponent<NPC>().fsm.SetState(StateID.Recovered);
        }

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ValueManager.Instance.day++;
            timer = ValueManager.Instance.secForDay;
        }
    }
}
