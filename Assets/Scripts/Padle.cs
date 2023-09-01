using UnityEngine;

public class Padle : MonoBehaviour
{
    private Vector3 _startPosition;

    public void Restart()
    {
        transform.position = _startPosition;
    }

    private void Awake()
    {
        _startPosition = transform.position;
    }
}
