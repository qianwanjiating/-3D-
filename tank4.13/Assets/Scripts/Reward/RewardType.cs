using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Reward_Type
{
    Atk,
    Def,
    MaxHp,
    Hp,
}
public class RewardType : MonoBehaviour
{
    public int value;
    public Reward_Type a = Reward_Type.Atk;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
       
    if(other.CompareTag("Player"))
        {
        PlayerTank player = other.GetComponent<PlayerTank>();
        switch (a)
        {
            case Reward_Type.Atk:
                player.atk += value;
                break;
            case Reward_Type.Def:
                player.def += value;
                break;
            case Reward_Type.MaxHp:
             player.maxHp +=value;
            GamePanel.Instance.UpdataHP(player.maxHp,player.hp);
                break;
            case Reward_Type.Hp:
                player.hp += value;
                if(player.hp > player.maxHp)
                    player.hp = player.maxHp;
                    GamePanel.Instance.UpdataHP(player.maxHp, player.hp);
                break;
        }
            Destroy(this.gameObject);
            GameObject obj=Instantiate(getEff,gameObject.transform.position,gameObject.transform.rotation);
            //控制音效
            AudioSource effAudio = getEff.GetComponent<AudioSource>();

            //控制音量大小
            effAudio.volume = GameDataMgr.Instance.music.soundValue;

            //通过是否静音(mute)来控制是否开启音效,取反->开启声音等于不静音，不开启声音等于静音
            effAudio.mute = !GameDataMgr.Instance.music.isOnSound;
            effAudio.Play();//避免没有勾选Play on Awake
            Destroy(obj,1f);
        }
    }

}
