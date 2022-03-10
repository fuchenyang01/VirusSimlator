using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ValueManager : MonoBehaviour
{
    public enum EnvironmentType
    {
        Outdoor,
        InDoor,
        Custom
    }

    public enum VirusType
    {
        Normal,
        Omicor
    }

    public enum Protective
    {
        None,
        Mask
    }
    public static ValueManager Instance = null;
    public int day = -3;
    public float secForDay = 1;
    public float EinfectRate;
    public float IinfectRate;
    public float planeSize = 0;
    public float initSpeed = 3.5f;
    public float initRunSpeed = 15.0f;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float runSpeed;
    public int SInitNum = 100, EInitNum = 0, IInitNum = 0, RInitNum = 0;//SEIR初始数量'
    public int SimulationDays = 0;
    [HideInInspector]
    public int SNum, ENum, INum, RNum;//SEIR初始数量'
    public float EDay = 1, IDay = 1, RDay = -1;//E潜伏期 I发病期 R是免疫保持期-1不生效
    public bool bIsolatezone = false; //是否有隔离区
    public EnvironmentType environmentType = EnvironmentType.InDoor;
    public VirusType virusType = VirusType.Normal;
    public Protective protective = Protective.None;

    public void Init()
    {
        Instance = this;
        SNum = SInitNum;
        ENum = EInitNum;
        INum = IInitNum;
        RNum = RInitNum;
        speed = initSpeed;
        runSpeed = initRunSpeed;
        Debug.Log("Init ValueManager...");
    }
    public void SetVirusData()
    {
        SNum = SInitNum;
        ENum = EInitNum;
        INum = IInitNum;
        RNum = RInitNum;
        if (virusType == VirusType.Normal)
        {
            EinfectRate =0.5f;
            IinfectRate =0.5f;
            EDay = 7;
            IDay =14;
        }
        else if(virusType == VirusType.Omicor)
        {
            EinfectRate =0.9f;
            IinfectRate =0.9f;
            EDay = 4;
            IDay =14;
        }

         if (protective == Protective.Mask)
        {
            EinfectRate*=0.2f;
            IinfectRate*=0.2f;
        }
    }
}
