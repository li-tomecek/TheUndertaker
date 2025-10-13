using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Hammer : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 1f;      //multiplier to input handling
    private IHittable _hoveredHittable;


    void OnTriggerEnter2d(Collider2D other)
    {
        IHittable hittable = other.gameObject.GetComponent<IHittable>();
        if (hittable != null)
        {
            //highlight whackable nail here
            _hoveredHittable = hittable;
        }
    }

    public void TryHit()
    {
        //play "hitting" animation, even if there is nothing to hit

        //play whoose/swing sound effect

        _hoveredHittable?.Hit();
    }
    
}
