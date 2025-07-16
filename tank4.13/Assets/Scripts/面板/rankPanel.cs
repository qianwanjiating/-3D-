using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankPanel : basePanel<rankPanel>
{
    
    private List<CustomGUILabel> Name= new List<CustomGUILabel>();
    private List<CustomGUILabel>Grade=new List<CustomGUILabel>();
    private List<CustomGUILabel>Time=new List<CustomGUILabel>();

    public CustomGUIButton closeBtn;
    // Start is called before the first frame update
    void Start()
    {
        hideMe();
        for(int i=1; i<=10;i++)
        {
            Name.Add(this.transform.Find($"名字/名字{i}").GetComponent<CustomGUILabel>());
            Grade.Add(this.transform.Find($"分数/分数{i}").GetComponent<CustomGUILabel>());
            Time.Add(this.transform.Find($"时间/时间{i}").GetComponent<CustomGUILabel>());
        }
        //用于测试是否添加成功
        //print(Name.Count);
        //print(Grade.Count);
        //print(Time.Count);

        closeBtn.clickEvent += () =>
        {
            hideMe();
            beginPanel.Instance.showMe();
           
        };

        //数据测试
        //GameDataMgr.Instance.AddRankInfo("测试数据1", 80, 660);

    }


    public override void showMe()
    {
        base.showMe();
        UpdateDataInfo();
    }

    public void UpdateDataInfo()//实时更新面板数据
    {
        //获取数据
        List<rankDataInfo> rankInfo = GameDataMgr.Instance.rankData.list;
        for(int i=0;i<rankInfo.Count;i++)
        {
            //添加名字
            Name[i].content.text = rankInfo[i].name;
            //添加成绩
            Grade[i].content.text = rankInfo[i].grade.ToString();
            //添加通关时间
            int time = (int)rankInfo[i].time;
            Time[i].content.text = "";
            if (time/3600>0)
            {
                Time[i].content.text += time / 3600 + "时";
            }
            if (time % 3608 / 60 > 0 || Time[i].content.text != "")
            {
                Time[i].content.text += time % 3600 / 60 + "分";
            }
            Time[i].content.text += time % 60 + "秒";
        }
    }
}
