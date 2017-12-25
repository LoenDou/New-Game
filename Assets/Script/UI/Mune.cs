using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif
//菜单
public class Mune : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup muneGroup;
    [SerializeField]
    private CanvasGroup optionGroup;
    [SerializeField]
    private CanvasGroup creditGroup;

    private Stack<CanvasGroup> canvasGroupStack = new Stack<CanvasGroup>();
    private List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();

    private void Start()
    {
        canvasGroupStack.Push(muneGroup);

        canvasGroupList.Add(creditGroup);
        canvasGroupList.Add(muneGroup);
        canvasGroupList.Add(optionGroup);
        DisplayMenu();
    }
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
    }
    public void StartButton()
    {

    }
    public void Esc()
    {
        if (canvasGroupStack.Count <= 1) return;
          canvasGroupStack.Pop();   
        DisplayMenu();

    }

    public void Setting()
    {
        canvasGroupStack.Push(optionGroup);
        DisplayMenu();
    }
    public void Credit()
    {
        canvasGroupStack.Push(creditGroup);
        DisplayMenu();
    }
    private void DisplayMenu()
    {
        foreach (var item in canvasGroupList)
        {
            item.alpha = 0;
            item.interactable = false;
            item.blocksRaycasts = false;
        }
        if (canvasGroupStack.Count > 0)
        {
            CanvasGroup cg = canvasGroupStack.Peek();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;

        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();

#endif 
    }
}
