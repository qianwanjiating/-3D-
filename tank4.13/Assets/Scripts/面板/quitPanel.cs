using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitPanel : basePanel<quitPanel>
{
    public CustomGUIButton closeBtn;//关闭面板
    public CustomGUIButton gameBtn;//继续游戏
    public CustomGUIButton quitBtn;//退出游戏

    public override void hideMe()
    {
        base.hideMe();
        Time.timeScale = 1;
    }

    public override void showMe()
    {
        base.showMe();

    }

    // Start is called before the first frame update
    void Start()
    {
        hideMe();
        gameBtn.clickEvent += () =>
        {
            hideMe();
        };
        quitBtn.clickEvent += () =>
        {
            SceneManager.LoadScene("SampleScene");
        };
        closeBtn.clickEvent += () =>
        {
            hideMe();
            Time.timeScale = 1;
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
