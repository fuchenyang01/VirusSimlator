using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ValueManager : MonoBehaviour
{
    public enum EnvironmentType
    {
        Outdoor,
        InDoor
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
    public int SNum = 100, ENum = 0, INum = 0, RNum = 0;//SEIR初始数量'
    public float EDay = 1, IDay = 1, RDay = -1;//E潜伏期 I发病期 R是免疫保持期-1不生效
    public bool bIsolatezone = false; //是否有隔离区
    public EnvironmentType environmentType = EnvironmentType.InDoor;
    public VirusType virusType = VirusType.Normal;
    public Protective protective = Protective.None;

    public void Init()
    {
        Instance = this;
        Debug.Log("Init ValueManager...");
    }
}
