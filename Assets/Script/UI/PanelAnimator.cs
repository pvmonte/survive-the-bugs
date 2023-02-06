using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelAnimator : MonoBehaviour
{
    private RectTransform rct;

    private void Start()
    {
        rct = GetComponent<RectTransform>();
    }

    public void Show()
    {
        GameController.current.buttonSrc.Play();
        rct.DOLocalMove(Vector2.zero, 0.5f);
    }

    public void Hide()
    {
        GameController.current.buttonSrc.Play();
        rct.DOLocalMove(Vector2.up * 1080, 0.5f);
    }
}
