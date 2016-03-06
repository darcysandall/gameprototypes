using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class RollingMovement : MonoBehaviour
{
    public int PlayerId = 1;
    public float Force = 5;

    private Movement _movement;

    void Start()
    {
        _movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetAxisRaw(ConvertControl("Horizontal")) != 0)
        {
            var horizontal = Input.GetAxisRaw(ConvertControl("Horizontal"))*Force;
            _movement.Rigidbody.AddRelativeForce(horizontal, 0, 0, ForceMode.Impulse);
        }
    }

    private string ConvertControl(string control)
    {
        return string.Format("{0}{1}", control, PlayerId);
    }
}
