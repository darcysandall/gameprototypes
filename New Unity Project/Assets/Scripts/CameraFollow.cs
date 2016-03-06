using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 TargetOffset = new Vector3(0, 3.5f, 7);
	
	void Update ()
	{
	    if (!Target) return;

	    transform.position = Target.position + TargetOffset;
	}
}
