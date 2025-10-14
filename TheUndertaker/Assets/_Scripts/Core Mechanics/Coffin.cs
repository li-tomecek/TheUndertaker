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
            //Swap to GameOver Scene here (or do it though a game manager)
            //Remove or DOTWeen move the lid sprite
        }  
    }
}