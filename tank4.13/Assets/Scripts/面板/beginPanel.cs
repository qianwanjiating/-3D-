using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class beginPanel : basePanel<beginPanel>
{
    public CustomGUIButton beginBtn;
    public CustomGUIButton settingBtn;
    public CustomGUIButton rankBtn;
    public CustomGUIButton quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        beginBtn.clickEvent += () =>
        {
            SceneManager.LoadScene("Game");
        };
        settingBtn.clickEvent += () => 
        {
           settingPanel.Instance.showMe();
           hideMe();
        };
        rankBtn.clickEvent += () =>
        {
            rankPanel.Instance.showMe();
            hideMe();   
        };
        quitBtn.clickEvent += () =>
        {
            Application.Quit();
            Debug.Log("quit");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
