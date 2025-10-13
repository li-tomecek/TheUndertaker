using System.Diagnostics;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Nail : MonoBehaviour, IHittable
{
    //will need reference to all sprite states?
    [SerializeField] int _numOfNailStates = 3;  //at this level, the nail is considered "popped out"
    private int _nailLevel;                     //0: hammered all the way in
    private bool _isPopped = false;             //Has the naul been papped out of the coffin (not hittable)

    public void Hit()
    {
        UnityEngine.Debug.Log("Nail has been hit");
        if (_nailLevel > 0)
            _nailLevel--;
    }
}
