using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCalculation : MonoBehaviour
{
    public Transform Player;
    public Transform endLinePosition;
    public Slider slider;

    GamesManager _gamesManager;
    PlayerController _playerController;

    float _maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gamesManager = FindObjectOfType<GamesManager>();
        _maxDistance = GetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.z <= _maxDistance && Player.position.z <= endLinePosition.position.z)
        {
            float distance = 1 - (GetDistance() / _maxDistance);
            SetProgress(distance);
        }   
    }

    float GetDistance()
    {
        return Vector3.Distance(Player.position,endLinePosition.position);
    }

    void SetProgress(float p)
    {
        slider.value = p;
        if (p >= 0.98)
        {
            _gamesManager.winpanel.SetActive(true);
            _playerController.GameControl = false;
        }
    }
}
