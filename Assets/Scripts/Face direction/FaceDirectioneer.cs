using UnityEngine;

public class FaceDirectioneer : MonoBehaviour
{
    private Quaternion _rightDirection = Quaternion.Euler(new Vector3(0, 0, 0));
    private Quaternion _leftDirection = Quaternion.Euler(new Vector3(0, 180, 0));

    public void SetFaceDirection(float direction)
    {
        if (direction > 0)
            transform.rotation = _rightDirection;
        else if (direction < 0)
            transform.rotation = _leftDirection;
    }
}