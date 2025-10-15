using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsMenu : MonoBehaviour
{
    [SerializeField] GameObject _winScreenObject, _loseScreenObject;
    [SerializeField] Button _mainMenuBtn;
    [SerializeField] float _buttonFadeInTime = 3f;

    void Start()
    {
        
    }

    public void FadeButtonIn()
    {

    }

    public void ReturnToMainMenu()
    {
        LevelManager.Instance.LoadMainMenu();
    }
}
