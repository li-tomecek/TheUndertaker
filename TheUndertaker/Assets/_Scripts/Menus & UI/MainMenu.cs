using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _startButton, _quitButton;

    private UnityAction _menuButtonSelect;

    void Start()
    {
        _menuButtonSelect = () => EventSystem.current.currentSelectedGameObject.GetComponent<Button>()?.onClick.Invoke();
        _startButton.Select();
        InputHandler.Instance.ButtonPressed.AddListener(_menuButtonSelect);
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
}
