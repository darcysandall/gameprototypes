using UnityEngine;
using System.Collections;

public class WatchPlayer : MonoBehaviour
{
    private Transform _player = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player = null;
        }
    }

    public Transform PlayerTransform()
    {
        return _player;
    }
}
