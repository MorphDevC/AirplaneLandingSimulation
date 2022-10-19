using DG.Tweening;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class ShowHideOptionsAnim : MonoBehaviour
{
    private CanvasGroup _targetCanvasGroup=null;
    private bool _isOpen;
    private void Awake()
    {
        _targetCanvasGroup = GetComponent<CanvasGroup>();
        _targetCanvasGroup.alpha = 0;
        _isOpen = false;
    }

    public void ShowHideOptionsArea()
    {
        if(_isOpen)
            HideOptionsArea();
        else
            ShowOptionsArea();
    }

    private void ShowOptionsArea()
    {
        if(_targetCanvasGroup==null)
            return;
        _targetCanvasGroup.DOFade(1, 0.2f);
        _isOpen = true;
    }
    
    private void HideOptionsArea()
    {
        if(_targetCanvasGroup==null)
            return;
        _targetCanvasGroup.DOFade(0, 0.2f);
        _isOpen = false;
    }
}
