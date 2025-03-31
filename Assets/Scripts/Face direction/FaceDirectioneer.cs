using UnityEngine;

public class FaceDirectioneer : MonoBehaviour
{
    private Vector3 _rightDirection = new Vector3(0, 0, 0);
    private Vector3 _leftDirection = new Vector3(0, 180, 0);

    public void SetFaceDirection(int direction)
    {
        int rightDirection = 1;
        int leftDirection = -1;

        if (direction == rightDirection)
            transform.rotation = Quaternion.Euler(_rightDirection);
        else if (direction == leftDirection)
            transform.rotation = Quaternion.Euler(_leftDirection);
    }
}