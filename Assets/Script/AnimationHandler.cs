using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpeedCalculator))]
[RequireComponent(typeof(SpriteRenderer))]
public class AnimationHandler : MonoBehaviour
{
    public const string HorizontalMovement = "HorizontalMovement";
    public const string VerticalMovement = "VerticalMovement";

    private int _horizontalMovementID;
    private int _verticalMovementID;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private SpeedCalculator _speedCalculator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _speedCalculator = GetComponent<SpeedCalculator>();
        _horizontalMovementID = Animator.StringToHash(HorizontalMovement);
        _verticalMovementID = Animator.StringToHash(VerticalMovement);
    }

    private void Update()
    {
        if (_speedCalculator.SpeedX < 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
        
        _animator.SetFloat(_horizontalMovementID, Mathf.Abs(_speedCalculator.SpeedX));
        _animator.SetFloat(_verticalMovementID, _speedCalculator.SpeedY);
    }
}
