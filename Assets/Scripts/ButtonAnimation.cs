using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimation : MonoBehaviour
{
    private RectTransform rect;
    private Vector3 mScale;
    private Vector3 mScaleMax;
    private Vector3 mScaleMin;
    
    [SerializeField, Header("スケール拡大倍率")]
    private float mScaleUpRate = 1.2f;
    [SerializeField, Header("スケール縮小倍率")]
    private float mScaleDownRate = .9f; 
    [SerializeField, Header("スケール変更秒数")]
    private float mScaleChangeSec = .5f;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        mScale = rect.localScale;
        mScaleMax = mScale * mScaleUpRate;
        mScaleMin = mScale * mScaleDownRate;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ChangeScaleOnClick()
    {
        Sequence sequence = DOTween.Sequence()
            .OnStart(() =>
            {
                print("start");
            })
            .Append(rect.DOScale(mScaleMin, mScaleChangeSec))
            .Append(rect.DOScale(mScaleMax, mScaleChangeSec))
            .Append(rect.DOScale(mScale, mScaleChangeSec))
            .AppendCallback(() =>
            {
                print("end");
            });

        sequence.Play();
    }
}
