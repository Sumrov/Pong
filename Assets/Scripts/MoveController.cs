using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;
    private float _leftBorder;
    private float _rightBorder;

    private void Awake()
    {
        if (_speed == 0) _speed = 10;
        if (_left == KeyCode.None) _left = KeyCode.A;
        if (_right == KeyCode.None) _right = KeyCode.D;
        _leftBorder = Camera.main.ScreenToWorldPoint(new(Camera.main.pixelRect.xMin, 0, 0)).x;
        _rightBorder = Camera.main.ScreenToWorldPoint(new(Camera.main.pixelRect.xMax, 0, 0)).x;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(_left) && transform.position.x - transform.localScale.x / 2 > _leftBorder)
            Move(Vector3.left);

        if (Input.GetKey(_right) && transform.position.x + transform.localScale.x / 2 < _rightBorder)
            Move(Vector3.right);
    }

    private void Move(Vector3 direction)
    {
        transform.position += Time.deltaTime * _speed * direction;
    }
}
