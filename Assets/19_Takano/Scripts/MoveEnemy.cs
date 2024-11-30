using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Fade m_fade;
    SpriteRenderer m_spriteRenderer;
    Color m_color;
    
    float m_elapsedTime = 0.0f;            // �o�ߎ���
    public float m_deleteTime = 5.0f;      // ���b��������폜���邩
    public bool m_deleteFg = false;        // �폜���邩�ǂ���

    // Start is called before the first frame update
    void Start()
    {
        m_fade = GetComponent<Fade>();

        // �����͓����ɂ���
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_color = m_spriteRenderer.color;
        m_color.a = 0.0f;
        m_spriteRenderer.color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        // �t�F�[�h�C�����������Ă��Ȃ����
        if(m_fade.m_completeFadeIn == false)
        {
            m_fade.FadeIn();    // �t�F�[�h�C������
        }

        // �폜����b���ɂȂ�����폜�t���O�𗧂Ă�
        if(m_elapsedTime >= m_deleteTime)
        {
            m_deleteFg = true;
        }

        // �t�F�[�h�A�E�g������t���O�������Ă�����
        if (m_fade.m_fadeOutFg == true)
        {
            m_fade.FadeOut();   // �t�F�[�h�A�E�g����
        }
    }
}
