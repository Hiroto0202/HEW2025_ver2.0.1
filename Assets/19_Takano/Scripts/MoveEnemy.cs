using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Fade m_fade;
    SpriteRenderer m_spriteRenderer;
    Color m_color;
    
    float m_elapsedTime = 0.0f;            // 経過時間
    public float m_deleteTime = 5.0f;      // 何秒たったら削除するか
    public bool m_deleteFg = false;        // 削除するかどうか

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
        m_elapsedTime += Time.deltaTime;

        // フェードインが完了していなければ
        if(m_fade.m_completeFadeIn == false)
        {
            m_fade.FadeIn();    // フェードインする
        }

        // 削除する秒数になったら削除フラグを立てる
        if(m_elapsedTime >= m_deleteTime)
        {
            m_deleteFg = true;
        }

        // フェードアウトをするフラグが立っていたら
        if (m_fade.m_fadeOutFg == true)
        {
            m_fade.FadeOut();   // フェードアウトする
        }
    }
}
