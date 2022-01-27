using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToucanSystems;
public class DrawGraph : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SmartChart;
    SmartChart sc;
    private List<Vector2> chartDataListS, chartDataListE, chartDataListI, chartDataListR;

    public Text r0;
    void Start()
    {
        InvokeRepeating("UpdateSmartChart", 0, 1);
        sc = SmartChart.GetComponent<SmartChart>();
        chartDataListS = new List<Vector2>();
        chartDataListE = new List<Vector2>();
        chartDataListI = new List<Vector2>();
        chartDataListR = new List<Vector2>();
    }

    // Update is called once per frame
    void UpdateSmartChart()
    {

        sc.minXValue = 0;
        sc.maxXValue = ValueManager.Instance.day + 4;
        sc.minYValue = 0;
        sc.maxYValue = ValueManager.Instance.INum + ValueManager.Instance.ENum + ValueManager.Instance.SNum + ValueManager.Instance.RNum;


        chartDataListS.Add(new Vector2(ValueManager.Instance.day + 4, ValueManager.Instance.SNum));
        sc.chartData[0].data = chartDataListS.ToArray();

        chartDataListE.Add(new Vector2(ValueManager.Instance.day + 4, ValueManager.Instance.ENum));
        sc.chartData[1].data = chartDataListE.ToArray();

        if (chartDataListE.Count > 1)
        {
            float R0 = chartDataListE[chartDataListE.Count - 1].y / chartDataListE[chartDataListE.Count - 2].y;
            if (chartDataListE[chartDataListE.Count - 2].y == 0)
                R0 = 0;
            r0.text = "R0=" + R0.ToString("#0.00");
        }




        chartDataListI.Add(new Vector2(ValueManager.Instance.day + 4, ValueManager.Instance.INum));
        sc.chartData[2].data = chartDataListI.ToArray();

        chartDataListR.Add(new Vector2(ValueManager.Instance.day + 4, ValueManager.Instance.RNum));
        sc.chartData[3].data = chartDataListR.ToArray();
        sc.SetupValues(true);
        sc.UpdateChart();
    }
}
