using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingPanel :basePanel<settingPanel>
{
    public CustomGUIToggle volumeToggle;//音量
    public CustomGUIToggle soundToggle;//音效
    public CustomGUISlider volunmeS;
    public CustomGUISlider sounds;
    public CustomGUIButton close;

    public AudioSource BKVolume;
    public AudioSource BKSound;
    // Start is called before the first frame update
    void Start()
    {
        hideMe();
        volumeToggle.changeValue += (value) =>GameDataMgr.Instance.volumeToggle(value);//当value变动时，传入一个当前value的值
        
        soundToggle.changeValue += (value) => GameDataMgr.Instance.soundToggle(value);

        volunmeS.changeValue += (value) => GameDataMgr.Instance.volumeS(value);

        sounds.changeValue += (value) => GameDataMgr.Instance.soundS(value);
       
        close.clickEvent += () =>
        {
            hideMe();
            if (SceneManager.GetActiveScene().name == "Game")
            {
                GamePanel.Instance.showMe();
            }
            else
            {
                beginPanel.Instance.showMe();
            }
        };
    }

    //用于实时更新最新的数据面板
    public void UpdatePanel()
    {

        volunmeS.nowValue = GameDataMgr.Instance.music.volumeValue;
        volumeToggle.isSel = GameDataMgr.Instance.music.isOnVolume;
        soundToggle.isSel = GameDataMgr.Instance.music.isOnSound;
        sounds.nowValue = GameDataMgr.Instance.music.soundValue;

    }

    public override void showMe()
    {
        base.showMe();
        UpdatePanel();
        Time.timeScale= 0;
    }
    public override void hideMe()
    {
        base.hideMe();
        Time.timeScale = 1;
    }
}
