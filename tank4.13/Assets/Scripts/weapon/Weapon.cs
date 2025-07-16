using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public GameObject bullet;
    //几个发射位置
    public Transform[] shootPos;
    //武器的拥有者(应该是用来判断谁发射的子弹？)
    public TankBaseObj fatherObj;

    //设置拥有者
    public void SetFather(TankBaseObj obj)
    {
        fatherObj= obj;
       
    }
   
    public void Fire()
    {
        for(int i=0;i<shootPos.Length;i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            Bullet bulletObj = obj.GetComponent<Bullet>();
            bulletObj.SetFather(fatherObj);
        }
    }
    
}
