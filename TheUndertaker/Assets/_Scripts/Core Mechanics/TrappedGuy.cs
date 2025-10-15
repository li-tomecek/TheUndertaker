using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TrappedGuy : MonoBehaviour
{
    [Header("Screams")]
    [SerializeField] float _minScreamWait = 5f;
    [SerializeField] float _maxScreamWait = 10f;
    [SerializeField] List<SFX> _screamsSFX = new List<SFX>();
    List<SFX> _unusedScreams = new List<SFX>();

    [Header("Nail Popping")]
    [SerializeField] float _minTimeBetweenPops = 1f;
    [SerializeField] float _maxTimeBetweenPops = 3f;

    private List<Nail> _nails = new List<Nail>();
    private float _popTimer, _screamTimer;

    private void Start()
    {
        _popTimer = GetNewTimer(_minTimeBetweenPops, _maxTimeBetweenPops);
        _screamTimer = GetNewTimer(_minScreamWait, _maxScreamWait);

        _nails = FindObjectsByType<Nail>(FindObjectsSortMode.None).ToList();   //probably should get this from coffin instead but good for now

        foreach (Nail nail in _nails)
        {
            nail.NailPopped.AddListener((val) => _nails.Remove(val));
        }

        _unusedScreams.AddRange(_screamsSFX);
    }

    private void Update()
    {
        _popTimer -= Time.deltaTime;
        _screamTimer -= Time.deltaTime;

        if (_popTimer <= 0f)
        {
            PopRandomNail();
            _popTimer = GetNewTimer(_minTimeBetweenPops, _maxTimeBetweenPops);
        }

        if (_screamTimer <= 0f)
        {
            if (_unusedScreams.Count == 0)
                _unusedScreams.AddRange(_screamsSFX);
            
            AudioManager.Instance.PlayRandomSound(_unusedScreams, out SFX clip);
            _unusedScreams.Remove(clip);

            //Maybe Shake the coffin here as well
            gameObject.GetComponent<ObjectShaker>().Shake();
            _screamTimer = GetNewTimer(_minScreamWait, _maxScreamWait);
        }
    }

    private float GetNewTimer(float min, float max)
    {
        return Random.Range(min, max);
    }


    private void PopRandomNail()
    {
        if (_nails.Count == 0) return;
        
        Nail nail;
        do
        {
            nail = _nails[Random.Range(0, _nails.Count)];
        }
        while (nail.IsPopped);  // just in case. This should not happen as the popped nails should be removed from the list                            
        nail.PopUp();
    }

}
