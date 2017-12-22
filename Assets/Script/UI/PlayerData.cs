using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//在assetmenu创建飞机数据云预制体选项并继承属性
 [CreateAssetMenu(fileName = "PlayerData", menuName = "CreateScriptable/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public int maxScore;
    }

