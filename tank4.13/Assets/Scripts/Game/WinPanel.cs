using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : basePanel<WinPanel>
{
    public CustomGUIButton sureBtn;
    public CustomGUIInput input;

    // Start is called before the first frame update
    void Start()
    {
        hideMe();

        sureBtn.clickEvent += () =>
        {
            SceneManager.LoadScene("SampleScene");
            GameDataMgr.Instance.AddRankInfo(input.content.text, GamePanel.Instance.nowsorce, GamePanel.Instance.nowTime);
            hideMe();
        };
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
