using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    MoveEnemy m_moveEnemy;              
    SpriteRenderer m_spriteRenderer;    // フェードするオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        m_moveEnemy = GetComponent<MoveEnemy>();
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //=============================================
    // オブジェクトをフェードイン
    //=============================================
    public void FadeIn()
    {
        Color _spriteColor = m_spriteRenderer.color;            // 現在のRGBAを取得
        float _duration = 1.5f;                                 // フェードにかける時間
        float _targetAlpha = 1.0f;                              // 最終のアルファ値

        // 現在のアルファ値が指定された値でない間
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // 透明度の変化値を求める

            // 求めた変化値ごとにアルファ値を変更する
            _spriteColor.a +=_changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
    }

    //=============================================
    // オブジェクトをフェードアウト
    //=============================================
    public void FadeOut()
    {
        Color _spriteColor = m_spriteRenderer.color;            // 現在のRGBAを取得
        float _duration = 1.5f;                                 // フェードにかける時間
        float _targetAlpha = 0.0f;                              // 最終のアルファ値

        // 現在のアルファ値が指定された値でない間
        if (_spriteColor.a > _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;    // 透明度の変化値を求める

            // 求めた変化値ごとにアルファ値を変更する
            _spriteColor.a -= _changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_moveEnemy.m_deleteFg = true;  // 敵の削除フラグを立てる
        }
    }
}
