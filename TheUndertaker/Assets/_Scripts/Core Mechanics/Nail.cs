using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Collider2D))]
public class Nail : MonoBehaviour, IHittable
{
    //will need reference to all sprite states?
    [SerializeField] int _numOfNailStates = 3;      //at this level, the nail is considered "popped out"
    private int _nailLevel;                         //0: hammered all the way in
    public bool IsPopped {get; private set;}                 //Has the nail been papped out of the coffin (not hittable)


    [Header("Nail State Sprites")]
    [SerializeField] SpriteRenderer _spriteRenderer;        //maybe want to put these in a list instead? (to fix when we get sprites)
    [SerializeField] Sprite _levelBottom;
    [SerializeField] Sprite _levelMiddle;
    [SerializeField] Sprite _levelTop;
    [SerializeField] GameObject _highlight;

    public UnityEvent NailPopped = new UnityEvent();

    public void Hit()
    {
        UnityEngine.Debug.Log("Nail has been hit");
        if (_nailLevel > 0)
            _nailLevel--;
        
        ChangeNailSprite();
    }


    private void PopUp()
    {
        _nailLevel++;
        ChangeNailSprite();

        if(_nailLevel >= _numOfNailStates){
            IsPopped = true;
            _highlight.SetActive(false);
            NailPopped?.Invoke();
        }
    }

    private void ChangeNailSprite()
    {
        switch(_nailLevel){
            case 0:
                _spriteRenderer.sprite = _levelBottom;
                break;
            case 1:
                _spriteRenderer.sprite = _levelMiddle;
                break;
            case 2:
                _spriteRenderer.sprite = _levelTop;
                break;
            default:
                _spriteRenderer.enabled = false;
                break;
        }
    }

    #region Trigger Enter/Exit
    void OnTriggerEnter2D(Collider2D other)
    {
        Hammer hammer = other.gameObject.GetComponent<Hammer>();

        if (hammer != null)
        {
            _highlight.SetActive(true);
            hammer.SetHittable(this);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Hammer hammer = other.gameObject.GetComponent<Hammer>();

        if (hammer != null)
        {
           _highlight.SetActive(false);
            hammer.SetHittable(null);       //this may work short-term but may cause problems if there are overlapping hittables!
        }
    }

    #endregion
}
