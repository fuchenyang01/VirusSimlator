using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWnd : WindowRoot 
{
    public ToggleGroup EnvironmentType;
    public ToggleGroup VirusType;
    public ToggleGroup Isolatezone;
    public ToggleGroup Protective;
    public InputField InputField;
    public InputField SNum;
    public InputField ENum;
    public InputField INum;
    public InputField RNum;
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
                    case "Custom":
                        valueManager.environmentType = ValueManager.EnvironmentType.Custom;
                        if (InputField.text!=null&&InputField.text!="")
                        {
                            valueManager.planeSize = float.Parse(InputField.text);
                        }
                        else
                        {
                            valueManager.planeSize = 1;
                        }
                        valueManager.speed/=valueManager.planeSize;
                        valueManager.runSpeed/=valueManager.planeSize;
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
        valueManager.SInitNum = int.Parse(SNum.text);
        valueManager.EInitNum = int.Parse(ENum.text);
        valueManager.IInitNum = int.Parse(INum.text);
        valueManager.RInitNum = int.Parse(RNum.text);
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
        else if(valueManager.environmentType == ValueManager.EnvironmentType.Outdoor)
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
        else if (valueManager.environmentType == ValueManager.EnvironmentType.Custom)
        {
            if (valueManager.bIsolatezone)
            {
                levelManager.LoadScene("CustomIsolatezone");
            }
            else
            {
                levelManager.LoadScene("Custom");
            }
        }
    }
    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}