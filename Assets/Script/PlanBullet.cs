using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanBullet : Bulletbase
{
  
    private Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();

    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        trans.Translate(Vector3.up * Time.deltaTime *-speedd );
        Destroy(this.gameObject, 3);
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boss"  || other.tag == "Bossbullet")
        {
            Destroy(this.gameObject);
        }



    }
}