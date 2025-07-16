using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKmusic : MonoBehaviour
{
    private AudioSource BK_music;
    private static BKmusic instance;
    public static BKmusic Instance=>instance;

    private void Awake()
    {
        instance= this;
        BK_music= GetComponent<AudioSource>();
        //初始化先前保留的这两个数据
        IsOnBkmusic(GameDataMgr.Instance.music.isOnVolume);//在GameDataMgr里面传入实际的数据
        ChangeVolume(GameDataMgr.Instance.music.volumeValue);
    }
 

    public void IsOnBkmusic(bool value)
    {
        BK_music.mute = !value;
    }
    public void ChangeVolume(float value)
    {
        BK_music.volume=value;
    }
}
