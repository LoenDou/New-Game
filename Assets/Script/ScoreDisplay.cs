﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class ScoreDisplay : MonoBehaviour {
    private LevelDirector director;

    [SerializeField]
    private Text scoreText, maxScoreText;
    [SerializeField]
    private GameObject[] lifeIcons;

	
	private void Start () {
        director = LevelDirector.Instance;
		
	}
	
	
	private void Update () {
        scoreText.text = director.Score.ToString();
        maxScoreText.text = director.MaxScore.ToString();
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < director.playerlifecount);
        }

    }
}
