using UnityEngine;

public class SpeedCalculator : MonoBehaviour
{
    private Vector3 _lastPosition;
    private float _speedX;
    private float _speedY;
    private float _animatorCoefficient;

    public float SpeedX => _speedX;
    public float SpeedY => _speedY;

    private void Start()
    {
        _lastPosition = transform.position;
        _animatorCoefficient = 10000;
    }

    private void Update()
    {
        var _currentPosition = _lastPosition - transform.position;
        _lastPosition = transform.position;
        _speedX = _currentPosition.x * _animatorCoefficient * Time.deltaTime;
        _speedY = _currentPosition.y * _animatorCoefficient * Time.deltaTime;
    }
}
