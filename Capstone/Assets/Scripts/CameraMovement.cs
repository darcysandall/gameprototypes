using UnityEngine;
using System.Collections;


/// <summary>
/// Class  CameraMovement.
/// 
/// Attached to each players camera
/// </summary>

public class CameraMovement : MonoBehaviour
{

    public Transform _player;
    public Vector3 _cameraOffset = new Vector3(0, 6, -6);
    public Quaternion _cameraRotation = Quaternion.Euler(45f, 0f, 0f);


    /// <summary>
    /// Sets initial camera location and rotation. Called every frame referencing player position and adjusting camera by offset
    /// </summary>
    void Update()
    {
        if (!_player)
        {
            return;
        }
        else
        {
            transform.position = _player.position + _cameraOffset;
            transform.rotation = _cameraRotation;
        }

    }
}
