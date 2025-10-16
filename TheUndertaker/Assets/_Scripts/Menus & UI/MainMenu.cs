using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _startButton, _quitButton;

    private UnityAction _menuButtonSelect;

    void OnEnable()
    {
        _startButton.Select();
        if (EventSystem.current == null) Debug.Log("no event system...");
        _menuButtonSelect = () => EventSystem.current.currentSelectedGameObject?.GetComponent<Button>()?.onClick.Invoke();
        InputHandler.Instance.ButtonPressed.AddListener(_menuButtonSelect);
        //InputHandler.Instance.NewMovement.AddListener((val) => ToggleSelectedButton());     //Not sure I need this but just in case.
    }
    void OnDisable()
    {
        InputHandler.Instance.ButtonPressed.RemoveListener(_menuButtonSelect);
    }

    public void StartGame()
    {
        LevelManager.Instance.LoadGameScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // public void ToggleSelectedButton()  //THIS IS CAUSING ISSUES
    // {
    //     Button btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
    //     if(btn == null)
    //     {
    //         _startButton.Select();
    //     } 
    // }
}
