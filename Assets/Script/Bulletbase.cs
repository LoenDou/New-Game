﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Bulletbase : MonoBehaviour
{
    [SerializeField]
    protected float speedd = 1f;
    [SerializeField]
    protected int power = 1;
    private string myTag;
    protected Transform trans;
    private void Awake() {
        trans = GetComponent<Transform>();
        myTag = gameObject.tag;

    }
    private void Update()
    {
        Move();
    }
    protected abstract void Move();
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IHealth>() != null && !collision.CompareTag(myTag))
        {
            collision.GetComponent<IHealth>().Damage(power);
        }
    }
   





}
