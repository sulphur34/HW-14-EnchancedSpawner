using System.Collections;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    private Transform _target;
    private float _speed;        
    private Coroutine _coroutine;

    public void Init(Transform target, float speed)
    {
        _target = target;
        _speed = speed;
    }
        
    public IEnumerator MoveToTarget()
    {
        while (_target.position != transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _target.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
