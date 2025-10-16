using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultsMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup _winScreen, _loseScreen;
    [SerializeField] Button _mainMenuBtn;
    [SerializeField] float _fadeInTime = 3f;

    private UnityAction _menuButtonSelect;

    void OnEnable()
    {
        _winScreen.alpha = 0;
        _loseScreen.alpha = 0;
        //_mainMenuBtn.gameObject.SetActive(false);
        if (GameManager.Instance.GameWon)
            FadeIn(_winScreen);
        else
            FadeIn(_loseScreen);

        if (EventSystem.current == null) Debug.Log("no event system...");
        _menuButtonSelect = () => EventSystem.current.currentSelectedGameObject?.GetComponent<Button>()?.onClick.Invoke();
        InputHandler.Instance.ButtonPressed.AddListener(_menuButtonSelect);
    }
    
    void OnDisable()
    {
        //InputHandler.Instance.ButtonPressed.RemoveListener(_menuButtonSelect);
    }
    
    public void FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.DOFade(1f, _fadeInTime).OnComplete(() => { _mainMenuBtn.gameObject.SetActive(true);  _mainMenuBtn.Select(); });
    }

    public void ReturnToMainMenu()
    {
        LevelManager.Instance.LoadMainMenu();
    }
}
