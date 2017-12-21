using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bulletbase
{
    [SerializeField]
    private float speed1 = -1f;
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
        trans.Translate(Vector3.up * Time.deltaTime * (-5));
        Destroy(this.gameObject, 3);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"  || other.tag == "bullet")
        {
            Destroy(this.gameObject);
        }



    }
}