using UnityEngine;

public class FaceDirectioneer : MonoBehaviour
{
    private Vector3 _rightDirection = new Vector3(0, 0, 0);
    private Vector3 _leftDirection = new Vector3(0, 180, 0);

    public void SetFaceDirection(Transform transform, int direction)
    {
        if (direction == 1)
            transform.rotation = Quaternion.Euler(_rightDirection);
        else if (direction == -1)
            transform.rotation = Quaternion.Euler(_leftDirection);
    }
}