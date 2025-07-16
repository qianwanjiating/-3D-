using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance=new GameDataMgr();

    public static GameDataMgr Instance=>instance;
    public musicData music;
    public rankList rankData;
    public GameDataMgr()
    {
         music = PlayerPrefsDataMgr.Instance.LoadData(typeof(musicData),"Music") as musicData;

        if(!music.isFirstOn)
        {
            music.isFirstOn = true;
            music.volumeValue = 1;
            music.soundValue= 1;
            music.isOnVolume = true;
            music.isOnSound= true;
           PlayerPrefsDataMgr.Instance.SaveData(music, "Music");
        }
        rankData=PlayerPrefsDataMgr.Instance.LoadData(typeof(rankList),"Rank") as rankList;
    }
    
 
    //提供给外部调用的数据更新api

    public void soundToggle(bool value)//将传入的value赋给music.isOnSound，并将他保存在Music里面
    {
        music.isOnSound = value;
        PlayerPrefsDataMgr.Instance.SaveData(music, "Music");
    }
    public void volumeToggle(bool value)
    {
        music.isOnVolume = value;
        BKmusic.Instance.IsOnBkmusic(music.isOnVolume);
        PlayerPrefsDataMgr.Instance.SaveData(music, "Music");
    }
    public void volumeS(float value)
    {
        music.volumeValue = value;
        BKmusic.Instance.ChangeVolume(music.volumeValue);
        PlayerPrefsDataMgr.Instance.SaveData(music, "Music");
    }
    public void soundS(float value)
    {
        music.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(music, "Music");
    }

    //提供该外部调用的排行榜数据更新的api
    public void AddRankInfo(string name, float grade,float time)
    {
        //添加数据
        rankData.list.Add(new rankDataInfo(name, grade, time));
        //排序
        rankData.list.Sort((a, b) => { return a.time>b.time?1:-1; });//自定义排序，加lambda表达式     
       
        //移除10条以外的数据
        for(int i=rankData.list.Count-1; i>=10; i--)
        {
            rankData.list.RemoveAt(i);
        }
        
        //存储数据
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
          
    }
}
