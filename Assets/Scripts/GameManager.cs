using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Difficult _difficult;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Ball _ball;
    [SerializeField] private Padle _padle;

    private void Start()
    {
        if ((int)_difficult == 0) _difficult = Difficult.Easy;
        StartGame();
    }

    private void StartGame()
    {
        _gameOver.SetActive(false);
        _ball.Restart(_difficult);
        _padle.Restart();
        _ball.Exploded += GameOver;
        _timer.StartTime();
    }

    private void GameOver()
    {
        _ball.Exploded -= GameOver;
        _gameOver.SetActive(true);
        _timer.StopTime();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartGame();
    }
}

public enum Difficult
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}
