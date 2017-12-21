using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public  class MyPlan : MonoBehaviour,IHealth
{
   
    private  AudioSource builletAudio;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject boom;


    private int i;
    private Vector2 v1;
    private Transform trans;
    private Vector3 lastPos;
    private Vector3 vectorSpeed;
    private Rigidbody2D rig;
    private float MaxX;
    private float MaxY;
    private float MinX;
    private float MinY;


    public delegate void OnDead();
    public event OnDead OnDeadEvent;


    private void Awake()
    {
        trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        builletAudio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        MaxX = ScreenXY.MaxX;
        MinX = ScreenXY.MinX;
        MaxY = ScreenXY.MaxY;
        MinY = ScreenXY.MinY;

    }
    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        trans.Translate(direction * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        ClampFrame();
    }

    private void FixedUpdate()
    {
        Move(v1);
    }
    private void ClampFrame()
    {
        trans.position = new Vector3(Mathf.Clamp(trans.position.x, MinX, MaxX),
                                     Mathf.Clamp(trans.position.y, MinY, MaxY),
                                     trans.position.z
                                    );
    }
    private void Move(Vector3 v1)
    {
        rig.velocity = v1 * speed;
    }





    private void Fire()
    {
        Instantiate(bullet, trans.position, Quaternion.identity);
        builletAudio.Play();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
    
       // if (!other.gameObject.CompareTag(gameObject.tag))
       if (other.tag=="Bossbullet" ||other .tag =="boss")
        {
            Damage(50);
       }

    }
    private int health = 200;
    public int Health { get { return health; } }
    public void Damage(int val)
    {
        health -= val;
        print("plan" + Health); 
            if (health <= 0)
        {
            DestroySelf();

        }
    }
    public void DestroySelf()
    {
        Instantiate(boom, trans.position, Quaternion.identity);//生成死亡动画
        if (OnDeadEvent != null)
        {
            OnDeadEvent();
        }
        Destroy(this.gameObject);
    }


}