using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Fade m_fade;
    SpriteRenderer m_spriteRenderer;
    Color m_color;
    
    float m_elapsedTime = 0;            // 経過時間
    public float m_deleteTime = 5;      // 何秒たったら削除するか
    public bool m_deleteFg = false;     // 削除するかどうか

    // Start is called before the first frame update
    void Start()
    {
        m_fade = GetComponent<Fade>();

        // 初期は透明にする
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_color = m_spriteRenderer.color;
        m_color.a = 0.0f;
        m_spriteRenderer.color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_spriteRenderer == null)
        {
            Debug.Log("m_spriteRendererがnull");
        }
        m_elapsedTime += Time.deltaTime;

        m_fade.FadeIn();    // フェードインする
        //FadeIn();    // フェードインする

        // 削除する秒数になったらフェードアウトする
        if ( m_elapsedTime >= m_deleteTime)
        {
            //m_fade.FadeOut();
            FadeOut();
            m_deleteFg = true;
        }
    }

    //=============================================
    // オブジェクトをフェードイン
    //=============================================
    public void FadeIn()
    {
        Color _spriteColor = m_spriteRenderer.color;            // 現在のRGBAを取得
        float _duration = 1.0f;                                 // フェードにかける時間
        float _targetAlpha = 1.0f;                              // 最終のアルファ値

        // 現在のアルファ値が指定された値でない間
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // 透明度の変化値を求める

            // 求めた変化値ごとにアルファ値を変更する
            _spriteColor.a += _changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
    }

    //=============================================
    // オブジェクトをフェードアウト
    //=============================================
    public void FadeOut()
    {
        Color _spriteColor = m_spriteRenderer.color;            // 現在のRGBAを取得
        float _duration = 1.0f;                                 // フェードにかける時間
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
            //m_deleteFg = true;  // 敵の削除フラグを立てる
        }
    }
}
