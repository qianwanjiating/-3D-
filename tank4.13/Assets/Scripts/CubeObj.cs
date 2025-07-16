using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewards;
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        int index=Random.Range(0, 100);
        if(other.CompareTag("Player"))
        {
            GamePanel.Instance.AddSorce(10);
        }
        //百分之50的概率刷新道具
        if(index<50)
        {
            index = Random.Range(0, rewards.Length);
            GameObject obj = Instantiate(rewards[index],gameObject.transform.position,gameObject.transform.rotation);
   
        }

        GameObject eff = Instantiate(deadEff, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(eff, 1);
        AudioSource audio = eff.GetComponent<AudioSource>();
        audio.volume = GameDataMgr.Instance.music.soundValue;
        audio.mute = !GameDataMgr.Instance.music.isOnSound;
        Destroy(gameObject);
    }
}
