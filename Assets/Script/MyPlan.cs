using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public  class MyPlan : MonoBehaviour,IHealth
{
   //生成窗口调节速度，子弹，爆炸，
    private  AudioSource builletAudio;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject boom;


    private int i;
    private Vector2 v1;
    private  Transform trans;
    private Vector3 lastPos;
    private Vector3 vectorSpeed;
    private Rigidbody2D rig;
    private float MaxX;
    private float MaxY;
    private float MinX;
    private float MinY;
    private BoxCollider2D r;

    private float fireRate =0.2f;
    private float fireTimer =0;
    private int health = 200;

    //声明委托事件
    public delegate void OnDead();
    public event OnDead OnDeadEvent;

    //程序初始化时获取数据
    private void Awake()
    {
        trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        builletAudio = GetComponent<AudioSource>();
        r = GetComponent<BoxCollider2D>();
       
    }
    private void Start()
    {
        MaxX = ScreenXY.MaxX;
        MinX = ScreenXY.MinX;
        MaxY = ScreenXY.MaxY;
        MinY = ScreenXY.MinY;
        r.enabled = false;
        StartCoroutine(Decorate());

    }
    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        trans.Translate(direction * Time.deltaTime * speed);


        if (Input.GetKey(KeyCode.Space))
        {
            FireStart();
        }
        //{
        //    Fire();
        //}
        ClampFrame();
     
    }
    public void FireStart()
    {
        if (health <= 0) return;
       
        fireTimer += Time.deltaTime;
      
        if (fireTimer > fireRate)
        {
            Instantiate(bullet, trans.position, Quaternion.identity);
            builletAudio.Play();

            // Instantiate(bullet, trans.position, Quaternion.identity);
            fireTimer = 0;
        }
    }

    //FixedUpdate，是在固定的时间间隔执行，不受游戏帧率的影响。有点想Tick。所以处理Rigidbody的时候最好用FixedUpdate
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
    private IEnumerator Decorate()
    {
        yield return new WaitForSeconds(2);
        r.enabled = true ;
       
    }





    //private void Fire()
    //{//创建子弹预设，（位置和角度）
    //    Instantiate(bullet, trans.position, Quaternion.identity);
    //    builletAudio.Play();

    //}
    void OnTriggerEnter2D(Collider2D other)
    {
    //进入trigger碰撞的条件(trigger不发生碰撞)
       // if (!other.gameObject.CompareTag(gameObject.tag))
       if (other.tag=="Bossbullet" ||other .tag =="boss")
        {
            Damage(50);
       }

    }//设置飞机血量
  //  private int health = 200;
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