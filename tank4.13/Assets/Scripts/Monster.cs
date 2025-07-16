using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : TankBaseObj
{
    public GameObject bullet;
    public Transform[] poss;

    //间隔开火时间
    public float fireTime=1f;

    private float nowTime = 0;

    public override void Dead()
    {
      
    }

    public override void Fire()
    {
       for(int i=0;i<poss.Length;i++) 
        {
         GameObject obj = Instantiate(bullet, poss[i].transform.position, poss[i].rotation);
            //设置子弹拥有者，方便后面的属性计算
         Bullet bullet1 =obj.GetComponent<Bullet>();
            bullet1.SetFather(this);
        }
    }

    public override void Wound(TankBaseObj other)
    {
    //什么都不写，敌人无法销毁，受伤
    }



    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if(nowTime >= fireTime) 
        {
            Fire();
            nowTime= 0;
        }
    }
}
