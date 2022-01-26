﻿using UnityEngine;
using UnityEngine.UI;

public class MenuWnd : WindowRoot 
{

    protected override void InitWnd()
    {
        base.InitWnd();

    }
    protected override void ClearWnd()
    {
        base.ClearWnd();

    }

    public void OnStartBtnClick()
    {
        levelManager.NextScence();
        valueManager.StartTimer();
    }
    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}