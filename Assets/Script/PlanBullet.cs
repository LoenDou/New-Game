using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//飞机子弹
public class PlanBullet : Bulletbase
{
  //获取生成位置
    private Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();

    }
    //射击方向
    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        trans.Translate(Vector3.up * Time.deltaTime *-speedd );
        Destroy(this.gameObject, 3);
    }



    //用OnTriggerEnter2D（碰撞前检测）方法判断是否自毁
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boss"  || other.tag == "Bossbullet")
        {
            Destroy(this.gameObject);
        }



    }
}