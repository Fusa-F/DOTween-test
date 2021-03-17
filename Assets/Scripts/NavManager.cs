using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NavManager : MonoBehaviour
{
    private bool mIsShow = false;
    private float mNavShowPosY = 220f;
    private float mNavHidePosY = 340f;
    private RectTransform rect;

    [SerializeField, Header("表示所要時間")]
    private float mNavShowSec = .5f;
    [SerializeField, Header("非表示所要時間")]
    private float mNavHideSec = .5f;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void NavButtonOnClick()
    {
        if(mIsShow)
        {
            HideNavAnimation();
            mIsShow = false;
        }else
        {
            ShowNavAnimation();
            mIsShow= true;
        }
    }

    private void ShowNavAnimation()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(rect.DOLocalMoveY(mNavShowPosY, mNavShowSec));

        sequence.Play();
    }

    private void HideNavAnimation()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(rect.DOLocalMoveY(-20f, mNavHideSec/2).SetRelative())
            .Append(rect.DOLocalMoveY(mNavHidePosY, mNavHideSec));

        sequence.Play();
    }
}
