using UnityEngine;
using MainMenu;

public class ScreenHandler : StateHandler
{
    [SerializeField] private string name;
    [SerializeField] private CanvasGroup canvasGroup;
    public override string Name => name;

    public override void OnEnter<T>(T transition)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit<T>(T transition)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }   

    private void Awake() {

        OnExit(MenuTransitions.MainMenuSelected);
        //canvasGroup.gameObject.SetActive(true);
        
    } 
}