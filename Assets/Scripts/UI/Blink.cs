using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Blink : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        StartCoroutine(Flash());
    }

    private void OnDisable()
    {
        StopCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        var delay = new WaitForSeconds(1f);
        
        while(true)
        {
            _canvasGroup.alpha = _canvasGroup.alpha == 1f ? .0f : 1f;
            yield return delay;
        }
    }
}
