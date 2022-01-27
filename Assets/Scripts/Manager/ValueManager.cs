using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public static ValueManager Instance = null;
    public int day = -3;
    public float secForDay = 1;
    public float EinfectRate;
    public float IinfectRate;
    public int SNum = 100, ENum = 0, INum = 0, RNum = 0;//SEIR初始数量'
    public float EDay = 1, IDay = 1, RDay = -1;//E潜伏期 I发病期 R是免疫保持期-1不生效

    private UIManager uiManager = null;
    public void Init()
    {
        Instance = this;
        uiManager = UIManager.Instance;
        Debug.Log("Init ValueManager...");
    }
}
