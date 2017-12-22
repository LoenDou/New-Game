using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDirector : MonoBehaviour {
    private static LevelDirector instance;
    public int  playerlifecount = 3;
    public Rigidbody2D r;
    public static LevelDirector Instance
         
    {
        get {
            if (instance == null)
            {
                throw new NullReferenceException("no  LevelDirector in scene");
            }
            return instance;
      }

    }
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
    }
    public int MaxScore
    {
        get { return maxScore; }
        private set { maxScore = value; }
    }
    private MyPlan   currentAirPlane;


    private void Awake() {
        instance = this;
   
        Init();       
    }



	private void Start () {
        StartCoroutine(Decorate());
		
	}
    private void Init() {
        mainAirplane = Resources.Load<MyPlan>("Prefabs/plan");
        bossPlane = Resources.Load<GameObject>("Prefabs/Enemys/boss");
        date = Resources.Load<PlayerData>("PlayerData");
    }
    private IEnumerator Decorate()
    {
        yield return new WaitForSeconds(2);
        currentAirPlane = Instantiate(mainAirplane, mainAirplane.transform.position, Quaternion.identity);
        currentAirPlane.OnDeadEvent += OnPlaneDead;//注册事件
        

        //Instantiate(bossPlane, bossPlane.transform.position, Quaternion.identity);
    }
	
	
	private void Update () {
		
	}

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
