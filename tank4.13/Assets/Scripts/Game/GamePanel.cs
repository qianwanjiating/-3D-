using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : basePanel<GamePanel>
{
    public CustomGUILabel gradeLab;//分数
    public CustomGUILabel timeLab;//时间
    public CustomGUIButton settingBtn;//设置按钮
    public CustomGUIButton quitBtn;//退出按钮
    public CustomGUITexture HPText;//血量

    [HideInInspector]
    public int nowsorce;//当前得分


    public int hpW=350;//HP图片的宽度，改变血量改变的就是图片的宽度

    public float nowTime;
    // Start is called before the first frame update
    void Start()
    {
        settingBtn.clickEvent += ()=>
        {
            settingPanel.Instance.showMe();
            Time.timeScale= 0;
        };
        quitBtn.clickEvent += () =>
        {
            quitPanel.Instance.showMe();
            Time.timeScale = 0;
        };
        AddSorce(0);
        UpdataHP(350,200);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        //添加通关时间
        int time = (int)nowTime;
        timeLab.content.text = "";
        if (time / 3600 > 0)
        {
            timeLab.content.text += time / 3600 + "时";
        }
        if (time % 3608 / 60 > 0 || timeLab.content.text != "")
        {
            timeLab.content.text += time % 3600 / 60 + "分";
        }
        timeLab.content.text += time % 60 + "秒";
    }
    /// <summary>
    /// 提供给外部的更新分数的方法
    /// </summary>
    /// <param name="sorce"></param>
    public void AddSorce(int sorce)
    {
        nowsorce += sorce;
        gradeLab.content.text= nowsorce.ToString();
    }
    /// <summary>
    /// 提供给外部的更新血条的方法，原理:得到当前血量与总血量的百分比，在更新相应百分比的宽度，就相当于更新了血条
    /// </summary>
    public void UpdataHP(int maxHP,int nowHP)
    {
        HPText.guiPos.width= (float)nowHP/maxHP*hpW;
    }

}
