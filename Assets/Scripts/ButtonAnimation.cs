using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnimation : MonoBehaviour
{
    private RectTransform rect;
    private Vector3 mScale;
    private Vector3 mScaleMax;
    private Vector3 mScaleMin;

    private bool mIsPushed = false;
    private Image image;
    
    [SerializeField, Header("スケール拡大倍率")]
    private float mScaleUpRate = 1.2f;
    [SerializeField, Header("スケール縮小倍率")]
    private float mScaleDownRate = .9f; 
    [SerializeField, Header("スケール変更秒数")]
    private float mScaleChangeSec = .5f;

    [SerializeField, Header("押下前カラー")]
    private Color mBeforeColor = Color.white;
    [SerializeField, Header("押下後カラー")]
    private Color mAfterColor = Color.red;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        mScale = rect.localScale;
        mScaleMax = mScale * mScaleUpRate;
        mScaleMin = mScale * mScaleDownRate;
        image = GetComponent<Image>();
        image.color = mBeforeColor;
    }

    public void ChangeScaleOnClick()
    {
        mIsPushed = mIsPushed ? false : true;
        Color color = mIsPushed ? mAfterColor : mBeforeColor;
        Sequence sequence = DOTween.Sequence()
            .Append(rect.DOScale(mScaleMin, mScaleChangeSec/2))
            .Append(rect.DOScale(mScaleMax, mScaleChangeSec))
            .AppendCallback(() =>
            {
                image.color = color;
            })
            .Append(rect.DOScale(mScale, mScaleChangeSec));

        sequence.Play();
    }
}
