using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {
    private Vector3  fireDirection;
   
   public  Transform barrelTrans;
    [SerializeField]
    private GameObject  bulletPrefab;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Transform plantrans;
    [SerializeField]
    private Transform pk;

    private float fireTimer;
    [SerializeField]
    private float fireRate;
    private void Awak()
    {

       
    }
    private void Start () {
		
	}
	
	
	private void Update () {
        if (LevelDirector.Instance.currentAirPlane == null) return;
        plantrans = LevelDirector.Instance.currentAirPlane .transform;

        BarrelRotate();
        fireTimer += Time.deltaTime;
        if (fireTimer > fireRate)
        {
            Fire();
            fireTimer = 0f;
        } 
	}
    private void BarrelRotate()
    {
        fireDirection = plantrans.transform.position - barrelTrans.transform.position;
        fireDirection.z = 0;
        fireDirection = fireDirection.normalized;
        barrelTrans.rotation = Quaternion.RotateTowards(barrelTrans.rotation, Quaternion.FromToRotation(Vector3.up, fireDirection), Time.deltaTime * rotateSpeed);

    }
    private void Fire()
    {
        Instantiate(bulletPrefab, pk .position, barrelTrans.rotation);
    }
}
