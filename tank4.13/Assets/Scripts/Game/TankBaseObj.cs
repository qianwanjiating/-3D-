using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //攻击力防御力相关
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    //旋转相关
    public float moveSpeed=10f;
    public float roundSpeed=100;
    public float headRoundSpeed=100;

    //炮台的头
    public GameObject head;

    //死亡特效
    public GameObject deadEff;

    /// <summary>
    /// 开火行为，不需要默认实现，子类重写即可
    /// </summary>
    public abstract void Fire();
    
    /// <summary>
    /// 被别人攻击，造成受伤
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        int dmg= other.atk - def;
        if (dmg <= 0)
            return;
        this.hp -= dmg;
        if(this.hp<=0)
        {
            Dead();
        }

    }
    /// <summary>
    /// 死亡行为
    /// </summary>
    public virtual void Dead()
    {
        //销毁自己
        Destroy(this.gameObject);
        //在销毁的地方生成死亡特效
        if(deadEff!=null)
        {
            //实例化对象，顺便同步位置和旋转
            GameObject effObj=Instantiate(deadEff,this.transform.position,this.transform.rotation);
            //控制音效
            AudioSource effAudio = effObj.GetComponent<AudioSource>();

            //控制音量大小
            effAudio.volume = GameDataMgr.Instance.music.soundValue;
            
            //通过是否静音(mute)来控制是否开启音效,取反->开启声音等于不静音，不开启声音等于静音
            effAudio.mute = !GameDataMgr.Instance.music.isOnSound;
            effAudio.Play();//避免没有勾选Play on Awake
        }

    }
}
