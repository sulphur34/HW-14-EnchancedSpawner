using System.Collections;
using UnityEngine;

public class FollowerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _waypointsContainer;
    [SerializeField] private Transform _target;
    [SerializeField] private Follower _follower;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _followersAmount;

    private Coroutine _coroutine;

    private void Awake()
    {
        _coroutine = StartCoroutine(AddFollower());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator AddFollower()
    {
        for (int i = 0; i < _followersAmount; i++)
        {
            var follower = Instantiate(_follower, transform.position, Quaternion.identity);
            follower.Init(_waypointsContainer, _target);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
