using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 基础面板类，包含了面板的基础功能
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class basePanel<T>:MonoBehaviour where T : class
{
    private static T instance;
    public static T Instance =>instance;

    private void Awake()
    {
        instance = this as T;
    }
    public virtual void showMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void hideMe()
    {
        this.gameObject.SetActive(false);
    }



}
