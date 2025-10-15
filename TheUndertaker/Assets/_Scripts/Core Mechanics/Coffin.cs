using UnityEngine;
using System.Collections.Generic;

public class Coffin : MonoBehaviour
{
    [SerializeField] List<Board> _boards = new List<Board>();
    private const int BOARDS_TO_LOSE = 2;
    private int _boardsRemoved;

    void Start()
    {
        foreach(Board board in _boards){
            board.BoardRemoved.AddListener(CheckForLoss);
        }
    }

    private void CheckForLoss()
    {
        _boardsRemoved++;
        if(_boardsRemoved >= BOARDS_TO_LOSE){
            //GAME IS LOST!!!!!!
            //Remove or DOTWeen move the lid sprite (Disable the hammer first, then DOTween, then open new scene)
            GameManager.Instance.OpenLoseScreen();
        }  
    }
}