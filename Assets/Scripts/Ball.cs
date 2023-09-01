using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public event Action Exploded;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private ParticleSystem _explosion;
    private float _speed;
    private float _topBorder;
    private float _rightBorder;
    private Vector3 _startPosition;
    private Vector3 _direction;
    private Difficult _difficult;

    public void Restart(Difficult difficult)
    {
        _difficult = difficult;
        transform.position = _startPosition;
        _direction = Random.insideUnitCircle.normalized;
        gameObject.SetActive(true);
        SetSpeed(1f);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
        _speedText.SetText(_speed.ToString());
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _topBorder = Camera.main.ScreenToWorldPoint(new(0f, Camera.main.pixelRect.yMax, 0f)).y;
        _rightBorder = Camera.main.ScreenToWorldPoint(new(Camera.main.pixelRect.xMax, 0f, 0f)).x;
        Restart(_difficult);
    }

    private void FixedUpdate()
    {
        if (transform.position.y - transform.localScale.y / 2 < -_topBorder)
            Explode();

        if (transform.position.y + transform.localScale.y / 2 > _topBorder)
            _direction.y = -_direction.y;
        
        if (transform.position.x + transform.localScale.x / 2 > _rightBorder || transform.position.x - transform.localScale.x / 2 < -_rightBorder)
            _direction.x = -_direction.x;
        
        Move();
    }

    private void Explode()
    {
        Exploded?.Invoke();
        _explosion.transform.position = transform.position;
        _explosion.Play();
        gameObject.SetActive(false);
    }

    private void Move()
    {
        transform.position += Time.deltaTime * _speed * _direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Padle padle)) 
        {
            _direction.x += transform.position.x < padle.transform.position.x ? -.3f : .3f;

            _direction.y = -_direction.y;
            SetSpeed(_speed + (float)_difficult);
        }
    }
}
