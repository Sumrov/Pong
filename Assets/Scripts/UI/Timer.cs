using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    private bool _on;
    private float _time;
    private TMP_Text _text;

    public void StartTime()
    {
        _time = 0;
        _on = true;
    }

    public void StopTime()
    {
        _on = false;
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!_on) return;

        _time += Time.deltaTime;
        int totalSeconds = (int)_time;

        int hours = totalSeconds / 3600;
        int minutes = totalSeconds % 3600 / 60;
        int seconds = totalSeconds % 60;

        var formattedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        _text.SetText(formattedTime);
    }
}
