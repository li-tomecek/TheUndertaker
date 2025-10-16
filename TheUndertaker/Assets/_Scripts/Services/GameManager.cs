using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : Singleton<GameManager>
{
    public bool GameWon;

    public void OpenWinScreen()
    {
        GameWon = true;
        LevelManager.Instance.LoadResultsScene();
    }
    
    public void OpenLoseScreen()
    {
        GameWon = false;
        LevelManager.Instance.LoadResultsScene();
    }

}
