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

    #region Trigger Enter/Exit
    void OnTriggerEnter2D(Collider2D other)
    {
        Hammer hammer = other.gameObject.GetComponent<Hammer>();

        if (hammer != null)
        {
            //highlight whackable nail here

            hammer.SetHittable(this);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Hammer hammer = other.gameObject.GetComponent<Hammer>();

        if (hammer != null)
        {
            //stop highlight here
            
            hammer.SetHittable(null);       //this may work short-term but may cause problems if there are overlapping hittables!
        }
    }

    #endregion
}
