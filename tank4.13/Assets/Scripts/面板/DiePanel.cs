using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePanel : basePanel<DiePanel>
{
    public CustomGUIButton againGame;
    public CustomGUIButton quitGame;
    // Start is called before the first frame update
    void Start()
    {
        hideMe();
        againGame.clickEvent+=()=>
        {
            SceneManager.LoadScene("Game");
            Time.timeScale=1;
        };
        quitGame.clickEvent+=()=> 
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
