using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankDataInfo
{
    public string name;
    public float grade;
    public float time;

    public rankDataInfo()//默认的无参构造
    {

    }
    public rankDataInfo(string name, float grade, float time)
    {
        this.name = name;
        this.grade = grade;
        this.time = time;
    }
}
/// <summary>
/// 排行榜列表
/// </summary>
public class rankList
{
   public List<rankDataInfo> list;
    
}

