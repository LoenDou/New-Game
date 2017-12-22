using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

#if UNITY_EDITOR
using UnityEditor;
#endif
//菜单
public class PauseMe : MonoBehaviour {
    [SerializeField]private AudioMixerSnapshot paused, unpaused;
    [SerializeField]private CanvasGroup pauseGroup;
    [SerializeField]private CanvasGroup settingGroup;

    private bool isPaused = false ;
    private Stack  <CanvasGroup>canvasGroupStack = new Stack<CanvasGroup>();
    private List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();

    private void Start ()
    {
        canvasGroupList.Add(pauseGroup);
        canvasGroupList.Add(settingGroup);
        DisplayMenu();
	}

	private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                    Esc();
        }	
	}
    private void lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(0.1f);
        }
        else
        {
            unpaused.TransitionTo(0.1f);
        }
    }
    public void Esc()
    {
        if (!isPaused && canvasGroupStack.Count == 0)
        {
            isPaused = !isPaused;
            canvasGroupStack.Push(pauseGroup);
        }
        else
        {
            if (canvasGroupStack.Count > 0)
                canvasGroupStack.Pop();

        }
        if (canvasGroupStack.Count == 0)
        {
            Pause();
        }
        DisplayMenu();
       
    }
    public void Pause()
    {
        isPaused = !isPaused;
        if (canvasGroupStack.Count > 0)
            canvasGroupStack.Pop();
        DisplayMenu();
    }
    public void Setting()
    {
        canvasGroupStack.Push(settingGroup);
        DisplayMenu();
    }
    private void DisplayMenu()
    {
        foreach (var item in canvasGroupList)
        {
            item.alpha = 0;
            item.interactable = false;
            item.blocksRaycasts  = false;
        }
        if (canvasGroupStack.Count > 0)
        {
            CanvasGroup  cg = canvasGroupStack .Peek();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;

        }
        Time.timeScale = isPaused ? 0 : 1;
        lowpass();
    }

   
    //public void Pause()
    //{
    //    isPaused = !isPaused;
    //    Time.timeScale = isPaused ? 0 : 1;
    //    pauseGroup.alpha = isPaused ? 1 : 0;
    //    pauseGroup.interactable = isPaused ? true : false;
    //    pauseGroup.blocksRaycasts = isPaused ? true : false;

    //}
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();

#endif 
    }
}
