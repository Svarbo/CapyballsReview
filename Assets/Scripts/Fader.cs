using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image _image;

    private float _fadeSpeed = 0.7f;
    private Coroutine _fadeInCoroutine;
    private Coroutine _fadeOutCoroutine;

    private void Start()
    {
        FadeOut();
    }

    public void Fade()
    {
        if (_fadeInCoroutine != null)
            StopCoroutine(_fadeOutCoroutine);

        if (_fadeInCoroutine != null)
            StopCoroutine(_fadeInCoroutine);

        _fadeInCoroutine = StartCoroutine(Darken());
    }

    private IEnumerator Darken()
    {
        _image.raycastTarget = true;

        Color imageColor = _image.color;

        while (_image.color.a < 1)
        {
            imageColor.a += _fadeSpeed * Time.deltaTime;
            _image.color = imageColor;

            yield return null;
        }

        FadeOut();
    }

    public void FadeOut()
    {
        _fadeOutCoroutine = StartCoroutine(Lighten());
    }

    private IEnumerator Lighten()
    {
        Color imageColor = _image.color;

        while (_image.color.a > 0)
        {
            imageColor.a -= _fadeSpeed * Time.deltaTime;
            _image.color = imageColor;

            yield return null;
        }

        _image.raycastTarget = false; 
    }
}