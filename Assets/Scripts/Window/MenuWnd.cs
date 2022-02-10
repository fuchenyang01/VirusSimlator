﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWnd : WindowRoot 
{
    public ToggleGroup EnvironmentType;
    public ToggleGroup VirusType;
    public ToggleGroup Isolatezone;
    public ToggleGroup Protective;
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
        IEnumerable<Toggle> Environment = EnvironmentType.ActiveToggles();
        foreach (Toggle t in Environment)
        {
            if (t.isOn)
            {
                switch (t.name)
                {
                    case "InDoor":
                        valueManager.environmentType = ValueManager.EnvironmentType.InDoor;
                        break;
                    case "OutDoor":
                        valueManager.environmentType = ValueManager.EnvironmentType.Outdoor;
                        break;
                }
                break;
            }
        }

        IEnumerable<Toggle> Virus = VirusType.ActiveToggles();
        foreach (Toggle t in Virus)
        {
            if (t.isOn)
            {
                switch (t.name)
                {
                    case "Normal":
                        valueManager.virusType = ValueManager.VirusType.Normal;
                        break;
                    case "Omicor":
                        valueManager.virusType = ValueManager.VirusType.Omicor;
                        break;
                }
                break;
            }
        }

        IEnumerable<Toggle> bIsolatezone = Isolatezone.ActiveToggles();
        foreach (Toggle t in bIsolatezone)
        {
            if (t.isOn)
            {
                switch (t.name)
                {
                    case "Yes":
                        valueManager.bIsolatezone =true;
                        break;
                    case "No":
                        valueManager.bIsolatezone =false;
                        break;
                }
                break;
            }
        }

        IEnumerable<Toggle> ProtectiveGroup = Protective.ActiveToggles();
        foreach (Toggle t in ProtectiveGroup)
        {
            if (t.isOn)
            {
                switch (t.name)
                {
                    case "None":
                        valueManager.protective = ValueManager.Protective.None;
                        break;
                    case "Mask":
                        valueManager.protective = ValueManager.Protective.Mask;
                        break;
                }
                break;
            }
        }


        valueManager.SetVirusData();

        if (valueManager.environmentType == ValueManager.EnvironmentType.InDoor)
        {
            if (valueManager.bIsolatezone)
            {
                levelManager.LoadScene("InDoorIsolatezone");
            }
            else
            {
                levelManager.LoadScene("InDoor");
            }
        }
        else
        {
            if (valueManager.bIsolatezone)
            {
                levelManager.LoadScene("OutDoorIsolatezone");
            }
            else
            {
                levelManager.LoadScene("OutDoor");
            }
        }

    }
    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}