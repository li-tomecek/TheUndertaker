using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
    [SerializeField] List<Nail> _nails = new List<Nail>();
    private int _nailsPopped;
    
    public bool IsBoardRemoved {get; private set;}
    public UnityEvent BoardRemoved  = new UnityEvent();
    
    void Start()
    {
        foreach(Nail nail in _nails){
            nail.NailPopped.AddListener(CheckForBoardRemoval);
        }
    }

    public void CheckForBoardRemoval()
    {
        _nailsPopped++;
        if(_nailsPopped >= _nails.Count)
        {
            IsBoardRemoved = true;
            BoardRemoved?.Invoke();
            //Hide board sprite, make sound
        }
    }

}
