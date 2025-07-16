using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up,speed*Time.deltaTime);
    }
}
