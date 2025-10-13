using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Hammer : MonoBehaviour
{
    [Range(0f, 50f)]
    [SerializeField] float _movementSpeed = 10f;      //multiplier to input handling
    private IHittable _hoveredHittable;

    private Vector2 _directionalInput, _newPosition;
    private Vector2 _boundsMin, _boundsMax;

    void Start()
    {
        InputHandler.Instance.NewMovement.AddListener(SetDirectionalInput);
        _boundsMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        _boundsMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }


    #region Hitting Nails
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
    #endregion



    #region Player Input and Movement
    private void SetDirectionalInput(Vector2 input)
    {
        _directionalInput = input;
    }

    private void UpdatePosition()
    {
        _newPosition = transform.position + ((Vector3)_directionalInput * _movementSpeed * Time.deltaTime);      //effectively a transform.Translate
        
        _newPosition.x = Mathf.Clamp(_newPosition.x, _boundsMin.x, _boundsMax.x);                       //Keeps the hammer within the bounds of the screen
        _newPosition.y = Mathf.Clamp(_newPosition.y, _boundsMin.y, _boundsMax.y);
        
        transform.position = _newPosition;
    }
    #endregion

}
