using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideManager : MonoBehaviour
{
    private bool mIsShow = false;
    private float mSideShowPosX = -480f;
    private float mSideHidePosX = -580f;
    private RectTransform rect;

    [SerializeField, Header("表示所要時間")]
    private float mSideShowSec = .5f;
    [SerializeField, Header("非表示所要時間")]
    private float mSideHideSec = .5f;

    private List<RectTransform> contentList = new List<RectTransform>();

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Transform contents = transform.Find("Contents");
        foreach(Transform child in contents)
        {
            contentList.Add(child as RectTransform);
        }
    }

    /// <summary>
    /// サイドバーの表示/非表示
    /// </summary>
    public void SideButtonOnClick()
    {
        if(mIsShow)
        {
            HideSideAnimation();
            mIsShow = false;
        }else
        {
            ShowSideAnimation();
            mIsShow= true;
        }
    }

    private void ShowSideAnimation()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(rect.DOLocalMoveX(mSideShowPosX, mSideShowSec))
            .AppendCallback(() =>
            {
                StartCoroutine(ShakeChildContent());
            });

        sequence.Play();
    }

    private void HideSideAnimation()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(rect.DOLocalMoveX(mSideHidePosX, mSideHideSec))
            .AppendCallback(() =>
            {
                StartCoroutine(ShakeChildContent());
            });

        sequence.Play();
    }

    /// <summary>
    /// サイドバーの子要素のアニメーション
    /// </summary>
    private IEnumerator ShakeChildContent()
    {
        foreach(RectTransform item in contentList)
        {
            if(!mIsShow) yield break;
            StartCoroutine(ChildContentAnimation(item));
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator ChildContentAnimation(RectTransform rectTransform)
    {
        Sequence sequence = DOTween.Sequence()
            .Append(rectTransform.DOLocalMoveY(4f, .2f).SetRelative())
            .Append(rectTransform.DOLocalMoveY(-4f, .2f).SetRelative());

        sequence.Play();
        yield return null;
    }
}
