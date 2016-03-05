using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform _target;
    public Vector3 _targetOffset = new Vector3(0, 3.5f, 7);
    public float _rotateDamping = 100f;

	void Start ()
    {
	    if (!_target)
	    {
	        Debug.Log("No target is attached to the camera.");
	    }
	}
	
	void Update ()
	{
	    if (!_target) return;

        Follow();
	    if (_rotateDamping > 0)
	    {
	        LookAtTarget();
	    }
	    else
	    {
	        transform.LookAt(_target.position);
	    }
	}

    private void LookAtTarget()
    {
        var rotation = Quaternion.LookRotation(_target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateDamping * Time.deltaTime);
    }

    private void Follow()
    {
        var cameraPosition = _target.position;
        cameraPosition += _targetOffset;
        var nextFramePosition = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime);
        transform.position = nextFramePosition;
    }
}
