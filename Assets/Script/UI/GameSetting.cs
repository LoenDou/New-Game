using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//在AssetMenu菜单创建预制文件GameSetting选项（第一行）
[CreateAssetMenu(fileName = "GameSetting", menuName = "CreeteScriptable/GameSetting", order = 1)]
//给它赋予属性
public class GameSetting : ScriptableObject
{//创建两个变量
    public float musicValume;
    public float effectValume;

}