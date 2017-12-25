using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRoll : MonoBehaviour {
    private Renderer rend;
    private Material mat;
    [SerializeField]
    private float speed = 1;



    private void Start () {
        rend = GetComponent<Renderer>();
        mat = rend.material;
		
	}
	
	
	private void Update () {
        mat.SetTextureOffset("_MainTex", new Vector3(0, speed *Time.time));
		
	}
}
