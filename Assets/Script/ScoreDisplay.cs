using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;
//导演
public class ScoreDisplay : MonoBehaviour {
    private LevelDirector director;

    [SerializeField]
    //生成两个text文本窗口
    private Text scoreText, maxScoreText;
    [SerializeField]
    //设置血条数组
    private GameObject[] lifeIcons;

	
	private void Start () {
        director = LevelDirector.Instance;
		
	}
	
	//将分数传入text文本
	private void Update () {
        scoreText.text = director.Score.ToString();
        maxScoreText.text = director.MaxScore.ToString();
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < director.playerlifecount);
        }

    }
}
