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
    public int initSNum = 100, initENum = 0, initINum = 0, initRNum = 0;//SEIR初始数量'
    public float EDay = 1, IDay = 1, RDay = -1;//E潜伏期 I发病期 R是免疫保持期-1不生效 这两个用来在外面输入 下面两个用于程序调用

    private UIManager uiManager = null;
    private float timer;
    private bool isStartTimer = false;
    public void Init()
    {
        Instance = this;
        uiManager = UIManager.Instance;
        Debug.Log("Init ValueManager...");
    }
    private void Update()
    {
        if (isStartTimer)
        {
            timer -= Time.deltaTime;
            if (timer<=0) 
            {
                day++;
                timer=secForDay;
            }
        }
    }
    public void StartTimer()
    {
        isStartTimer = true;
        timer=secForDay;
        day=-3;
    }
    public void StopTimer()
    {
        isStartTimer = true;
    }
}
