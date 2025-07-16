using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //看向的目标
    public Transform Target;
    
    //用于调节的向量
    private Vector3 pos;
    
    //自行在面板调节高度
    public float H=10;
    private void LateUpdate()
    {
        if (Target == null)
            return;
        pos.x = Target.transform.position.x;
        pos.z = Target.transform.position.z;
        pos.y = H;
        this.transform.position = pos;
    }
}
