using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public Vector3 TargetOffset = new Vector3(0, 3.5f, 7);
    public float RotateDamping = 100f;

	void Start ()
    {
	    if (!Target)
	    {
	        Debug.Log("No target is attached to the camera.");
	    }
	}
	
	void Update ()
	{
	    if (!Target) return;

        Follow();
	    if (RotateDamping > 0)
	    {
	        LookAtTarget();
	    }
	    else
	    {
	        transform.LookAt(Target.position);
	    }
	}

    private void LookAtTarget()
    {
        var rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotateDamping * Time.deltaTime);
    }

    private void Follow()
    {
        var cameraPosition = Target.position;
        cameraPosition += TargetOffset;
        var nextFramePosition = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime);
        transform.position = nextFramePosition;
    }
}
