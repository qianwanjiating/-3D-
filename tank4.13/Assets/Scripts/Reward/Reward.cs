using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public GameObject[] weapons;

    public GameObject GetRewardEff;

    //销毁时间
    public float time = 2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //获取随机武器下标
            int index = Random.Range(0, weapons.Length);
            //取出武器
            
            //player在别的物体上，获取时要加上other
            PlayerTank player = other.GetComponent<PlayerTank>();
            player.ChangeWeapon(weapons[index]);

            //销毁自己
            Destroy(this.gameObject);

          
                //创建特效
                GameObject obj = Instantiate(GetRewardEff, this.transform.position, this.transform.rotation);
                Destroy(obj, time);

                AudioSource audio = obj.GetComponent<AudioSource>();
                audio.volume = GameDataMgr.Instance.music.soundValue;
                audio.mute = !GameDataMgr.Instance.music.isOnSound;
            
        }
    }
}
