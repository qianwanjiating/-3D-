using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBaseObj
{
    //当前装备的武器
    public Weapon nowWeapon;

    //武器位置的父对象
    public Transform weaponPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按下WS移动
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*this.moveSpeed*Time.deltaTime);
        //按下AD键旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * this.roundSpeed * Time.deltaTime);
        //鼠标移动，坦克头旋转
        head.transform.Rotate(Input.GetAxis("Mouse X")*Vector3.up*this.headRoundSpeed* Time.deltaTime);

        //按下鼠标左键开火
        if(Input.GetMouseButtonDown(0)) 
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }

    
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdataHP(this.maxHp, this.hp);
    }
    //考虑加个死亡UI
    public override void Dead()
    {
       Time.timeScale= 0f;
        DiePanel.Instance.showMe();
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="weapon"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        if (nowWeapon != null)
        {
            Destroy(nowWeapon);
            nowWeapon = null;
        }

        //传入武器的父对象，不改变缩放之类的参数，不能直接传关联对象的位置和旋转，会导致武器停留在原地
       GameObject obj = Instantiate(weapon,weaponPos,false);
       nowWeapon = obj.GetComponent<Weapon>();

        //设置武器的拥有者
        nowWeapon.SetFather(this);
       
    }
}
