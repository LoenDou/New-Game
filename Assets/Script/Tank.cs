using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    [SerializeField]
    private float speed;
   
    private Rigidbody2D body;

    private void Awak()
    {
        // trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }
    private void Start () {
		
	}
	
	
	private void Update () {
      this.gameObject.transform .Translate(Vector3.left * speed * Time.deltaTime);
		
	}
}
