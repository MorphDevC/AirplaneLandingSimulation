using System;
using DG.Tweening;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private AirplaneManager _airplaneFlyingRef;

    private CanvasGroup _canvasGroup;
    private bool _isFadeIn = false;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _airplaneFlyingRef.OnButtonPressed += FadeInOut;
    }

    private void FadeInOut(object obj)
    {
        if (_isFadeIn)
            FadeIn();
        else
            FadeOut();
        _isFadeIn = !_isFadeIn;
    }

    private void FadeOut()
    {
        _canvasGroup.DOFade(0, 0.5f);
    }

    private void FadeIn()
    {
        _canvasGroup.DOFade(0.6f, 0.5f);
    }
}