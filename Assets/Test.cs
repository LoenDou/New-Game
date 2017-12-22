using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    public Image a;
    public Color A1;


	
	private void Start () {
		
	}
	
	
	private void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(FadeInOut.FadeImage(a,3f,A1));
        }
		
	}
}
