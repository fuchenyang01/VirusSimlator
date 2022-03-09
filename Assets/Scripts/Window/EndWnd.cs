using UnityEngine;
using UnityEngine.UI;
public class EndWnd : WindowRoot 
{
    public int checkDay = 10;
    public Button menuBtn;
    public bool isWin = false;
    public Transform hitPanel;
    public GameObject hitTxt;
    protected override void InitWnd()
    {
        base.InitWnd();
        Time.timeScale =0;

        if (valueManager.day >= checkDay)
        {
            if (isWin)
            {
                GameObject go = Instantiate(hitTxt, hitPanel);
                go.GetComponent<Text>().text = "Good Job! No suggestion!";
            }
            else
            {
                if (ValueManager.Instance.SNum + ValueManager.Instance.ENum + ValueManager.Instance.INum + ValueManager.Instance.RNum > 300)
                {
                    GameObject go = Instantiate(hitTxt, hitPanel);
                    go.GetComponent<Text>().text = "Overpopulation please reduce the population!";
                }
                if (ValueManager.Instance.environmentType == ValueManager.EnvironmentType.InDoor || (ValueManager.Instance.environmentType == ValueManager.EnvironmentType.Custom && ValueManager.Instance.planeSize < 3))
                {
                    GameObject go = Instantiate(hitTxt, hitPanel);
                    go.GetComponent<Text>().text = "Please expand the area!";
                }

                if (ValueManager.Instance.protective == ValueManager.Protective.None)
                {
                    GameObject go = Instantiate(hitTxt, hitPanel);
                    go.GetComponent<Text>().text = "Please wear a mask!";
                }
            }
        }
        else
        {
            GameObject go = Instantiate(hitTxt, hitPanel);
            go.GetComponent<Text>().text = "Simulation time is too short!";
        }
    }
    protected override void ClearWnd()
    {
        Time.timeScale =1;
        for (int i = 0; i <  hitPanel.childCount; i++)
        {
            Destroy(hitPanel.GetChild(i).gameObject);
        }
    }

    
    public void OnMenuBtnClick()
    {
        UIManager.Instance.endWnd.SetWindSate(false);
        LevelManager.Instance.LoadMenu();
    }
}