using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAnimation : MonoBehaviour
{
    public Text text;
    [SerializeField, Header("表示する文字")] private string str;

    private void Awake()
    {
        text.text="";
    }

    private void Start()
    {                                                                                                                                                                                       
        text.DOText("こんにちは。\nこれはテキストアニメーションのテストです。", 3)
            .SetEase(Ease.Linear);
    }

    private void Update()
    {                                   
        
    }

    private void        
}
