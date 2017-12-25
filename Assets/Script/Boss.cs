using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
 
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float repeatRate;
    [SerializeField]
    private GameObject boom;
    public int i;



    private void Start () {
        InvokeRepeating("Fire", 0f, repeatRate);

		
	}
	
	
	private void Update () {
       
		

	}
    private void Fire() {
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        for (int i = 0; i <= 360; i += 45)
        {
            Quaternion r = Quaternion.Euler(0, 0, i);
            Instantiate(bulletPrefab, this.transform.position, r );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "bullet")
       // if (!other.gameObject.CompareTag(gameObject.tag))
        {
            i++;
            if (i == 5)
            {
                
                Instantiate(boom, transform.position, Quaternion .identity );
                Destroy(this.gameObject);
            }

        }

        
    }
}
