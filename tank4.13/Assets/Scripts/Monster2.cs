using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : TankBaseObj
{
    //当前目标点
    public Transform traget;
    //随机目标点
    public Transform[] randomTarget;

    //玩家位置
    public Transform playerPos;

    public float time=1;
    public GameObject bullet;
    private float nowTime;

    public Transform[] firePos;


    //血条显示时间
    private float showTime;

    //两张 血条的图 外面关联
    public Texture maxHpBK;
    public Texture hpBK;


    //之所以没有new 是因为是结构体 可以不用new 直接在下面赋值
    private Rect maxHpRect;
    private Rect hpRect;
    public override void Fire()
    {
            for(int i=0;i<firePos.Length;i++) 
            {
                GameObject obj = Instantiate(bullet, firePos[i].transform.position, firePos[i].transform.rotation);
                //设置子弹拥有者，方便后面的属性计算
                Bullet bullet1 = obj.GetComponent<Bullet>();
                bullet1.SetFather(this);
            }
 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //开火
        nowTime += Time.deltaTime;
        if (nowTime >= time)
        {
             Fire();
            nowTime = 0;
        }
        //设置面朝向
        this.transform.LookAt(traget);
        //不断朝向面移动
        this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        //如果坦克与目标点的距离小于0.5，就说明已经到达这个点了
        if(Vector3.Distance(this.transform.position,traget.transform.position)<0.05f)
        {
            RandomPos();
        }
       //不断看向玩家
       this.transform.LookAt(playerPos);
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3;
    }

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddSorce(10);
    
    }
    public void RandomPos()
    {
        if (randomTarget.Length == 0)
            return;
        traget = randomTarget[Random.Range(0,randomTarget.Length)];

    }
    private void OnGUI()
    {
        if (showTime > 0)
        {
            //不停计时
            showTime -= Time.deltaTime;

            //画图 画血条
            //1.把怪物当前位置 转换成 屏幕位置
            //摄像机里面提供了API 可以将 世界坐标 转为 屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2.屏幕位置 转换成 GUI位置
            //知识点：如何得到当前屏幕的分辨率高
            screenPos.y = Screen.height - screenPos.y;

            //然后再绘制
            //知识点：GUI中的 图片绘制
            //底图
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            //画底图
            GUI.DrawTexture(maxHpRect, maxHpBK);

            hpRect.x = screenPos.x -50;
            hpRect.y = screenPos.y -50;
            //根据血量和最大血量的百分比 决定画多宽
            hpRect.width = (float)hp / maxHp * 100f;
            hpRect.height = 15;
            //画血条
            GUI.DrawTexture(hpRect, hpBK);
        }
    }
}
