using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPannel : MonoBehaviour {
    [SerializeField]
    //在面板中显示两个slider（滚动条）
    private Slider musicSlider;
    [SerializeField]
    private Slider effectSlider;

	
	private void Start () {
        //为其赋值
        musicSlider.value = AudioManager.Instance.MusicValume;
        effectSlider .value = AudioManager.Instance.EffectValume;

    }//声明一个将值赋给系统音乐的公有方法
    public void OnMusicSilider(float valume)
    {
        AudioManager.Instance.MusicValume = valume;

    }

    public void OnEffectSilder(float valume)
    {
        AudioManager.Instance.EffectValume = valume;
    }
	
}
