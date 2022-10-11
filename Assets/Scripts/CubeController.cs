using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Vector3 _distance;
    private float _speed;

    public void Run(Vector3 distance, float speed)
    {
        _distance = distance;
        _speed = speed;
        
        StartCoroutine(LiveCoroutine());
    }

    private IEnumerator LiveCoroutine()
    {
        var start = transform.position;
        var target = start + _distance;
        var duration = Vector3.Distance(target, start) / _speed;
        var t = 0f;

        while ((t += Time.deltaTime) < duration)
        {
            transform.position = Vector3.Lerp(start, target, t / duration);
            
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
