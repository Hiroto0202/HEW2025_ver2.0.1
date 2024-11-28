using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool m_isFadeIn = false;     // フェードインしているかどうか
    public bool m_isFadeOut = false;    // フェードアウトしているかどうか
    float m_fadeTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_isFadeIn);
        //Debug.Log(m_isFadeOut);
    }

    //=============================================
    // オブジェクトをフェードイン
    //=============================================
    public void FadeIn(GameObject _newObj)
    {
        m_isFadeIn = true;
        SpriteRenderer _spriteRenderer = _newObj.GetComponent<SpriteRenderer>();
        Color _spriteColor = _spriteRenderer.color;             // 現在のRGBAを取得
        _spriteColor.a = 0.0f;                                  // 透明にする

        float _duration = 0.5f;                                 // フェードにかける時間
        float _targetAlpha = 1.0f;                              // 最終のアルファ値

        // 現在のアルファ値が指定された値でない間
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // 透明度の変化値を求める

            // 求めた変化値ごとにアルファ値を変更する
            _spriteColor.a +=_changeSpeed;
            _spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_isFadeIn = true; // フェードイン完了
        }
    }

    //=============================================
    // オブジェクトをフェードアウト
    //=============================================
    public void FadeOut(GameObject _newObj)
    {
        m_isFadeOut = true;
        SpriteRenderer _spriteRenderer = _newObj.GetComponent<SpriteRenderer>();
        Color _spriteColor = _spriteRenderer.color;             // 現在のRGBAを取得

        float _duration = 0.5f;                                 // フェードにかける時間
        float _targetAlpha = 0.0f;                              // 最終のアルファ値

        // 現在のアルファ値が指定された値でない間
        if (_spriteColor.a > _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // 透明度の変化値を求める

            // 求めた変化値ごとにアルファ値を変更する
            _spriteColor.a -= _changeSpeed;
            _spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_isFadeOut = false;    // フェードアウト完了
        }
    }
}
