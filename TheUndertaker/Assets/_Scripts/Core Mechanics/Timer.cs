using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float _gameTimer = 60;
    [SerializeField] TextMeshProUGUI _timerText;

    
    
    public void Update()
    {
        _gameTimer -= Time.deltaTime;
        _gameTimer = Mathf.Max(_gameTimer, 0f);
       
       _timerText.text = $"{_gameTimer:0.0}";
        
        if(_gameTimer <= 0)
        {
            //GAME WON!
            GameManager.Instance.OpenWinScreen();
            //Debug.Log(" ~~~ GAME WON! ~~~");
        }
    }
}
