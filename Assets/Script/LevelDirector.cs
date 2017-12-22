using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//声明生存导演
public class LevelDirector : MonoBehaviour {
    private static LevelDirector instance;
    public int  playerlifecount = 3;
    public Rigidbody2D r;
    public static LevelDirector Instance
         
    {
        get {
            //如果为空，抛出异常
            if (instance == null)
            {
                throw new NullReferenceException("no  LevelDirector in scene");
            }
            return instance;
      }

    }
    //创建玩家 boss 数据，游戏结束 窗口
    [SerializeField ]
    private MyPlan   mainAirplane;
    [SerializeField]
    private GameObject bossPlane;
    [SerializeField]
    private PlayerData date;
    [SerializeField]
    private GameObject gameOverMenu;

    private int score;
    private int maxScore;
    //给分数score赋值
    public int Score {
        get { return score; }
        set {
            score = value;
            if (maxScore < score)
            {
                date.maxScore = value;
                maxScore = value;
            }

        }
    }//给最大值分数赋值
    public int MaxScore
    {
        get { return maxScore; }
        private set { maxScore = value; }
    }
    private MyPlan   currentAirPlane;

    //this（本物体）在初始化时实例化预制体

    private void Awake() {
        instance = this;
   
        Init();       
    }



	private void Start () {
        StartCoroutine(Decorate());
		
	}//Init方法为实例化预制体
    private void Init() {
        mainAirplane = Resources.Load<MyPlan>("Prefabs/plan");
        bossPlane = Resources.Load<GameObject>("Prefabs/Enemys/boss");
        date = Resources.Load<PlayerData>("PlayerData");
    }
    private IEnumerator Decorate()
    {

        //Enumerable接口非常简单，只包含一个抽象的方法GetEnumerator()，它返回一个可用于循环访问集合的IEnumerator对象
        //IEnumerator它是一个真正的集合访问器，没有它，就不能使用foreach语句遍历数组或集合，因为只有IEnumerator对象才能访问集合中的项，假如连集合中的项都访问不了，那么进行集合的循环遍历是不可能的事情了
        //yield关键字用于遍历循环中，yield return用于返回IEnumerable<T>,yield break用于终止循环遍历。
        yield return new WaitForSeconds(2);
        currentAirPlane = Instantiate(mainAirplane, mainAirplane.transform.position, Quaternion.identity);
        currentAirPlane.OnDeadEvent += OnPlaneDead;//注册事件
        

        //Instantiate(bossPlane, bossPlane.transform.position, Quaternion.identity);
    }
	
	
	private void Update () {
		
	}
    //玩家生命次数
    private void OnPlaneDead()//玩家生命
    {
        playerlifecount--;
        if (playerlifecount > 0)
        {
            StartCoroutine(Decorate());

        }
        else
        {
            gameover();
        }
    }
    public void gameover()
    {
       
    }
}
