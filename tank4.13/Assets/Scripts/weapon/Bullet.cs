using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;
    public GameObject deadEff;//销毁特效
    //谁发射的子弹
    public TankBaseObj fatherObj;

    //控制销毁时间
    public float time=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        this.transform.Translate(Vector3.forward* moveSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //如果武器拥有者被销毁，就不执行下面的代码
        if(fatherObj==null)
        {
            return;
        }
        //如果撞到了cube，子弹销毁。如果是带有敌人标签的子弹撞到了带有玩家标签的子弹，子弹销毁，如果是带有玩家标签的子弹撞到了带有敌人标签的子弹，子弹销毁
        if(other.CompareTag("cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster")&&fatherObj.CompareTag("Player"))
        {
            //受伤判定，通过父对象获取碰撞对象上是否有坦克脚本，用里氏替换原则
            TankBaseObj obj1 = other.GetComponent<TankBaseObj>();
            if(obj1 != null) 
            {
                obj1.Wound(fatherObj);
            }

            if (deadEff != null)
            {
              GameObject obj =  Instantiate(deadEff);
              AudioSource audioSource= obj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.music.soundValue;
                audioSource.mute = !GameDataMgr.Instance.music.isOnSound;
                audioSource.Play();

                Destroy(obj, time);
            }
            Destroy(this.gameObject);
        }
    }
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
