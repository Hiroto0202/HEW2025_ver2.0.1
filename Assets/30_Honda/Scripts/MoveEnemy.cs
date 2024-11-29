using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Fade m_fade;
    SpriteRenderer m_spriteRenderer;
    Color m_color;
    
    float m_elapsedTime = 0;            // �o�ߎ���
    public float m_deleteTime = 5;      // ���b��������폜���邩
    public bool m_deleteFg = false;     // �폜���邩�ǂ���

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
        if (m_spriteRenderer == null)
        {
            Debug.Log("m_spriteRenderer��null");
        }
        m_elapsedTime += Time.deltaTime;

        m_fade.FadeIn();    // �t�F�[�h�C������
        //FadeIn();    // �t�F�[�h�C������

        // �폜����b���ɂȂ�����t�F�[�h�A�E�g����
        if ( m_elapsedTime >= m_deleteTime)
        {
            //m_fade.FadeOut();
            FadeOut();
            m_deleteFg = true;
        }
    }

    //=============================================
    // �I�u�W�F�N�g���t�F�[�h�C��
    //=============================================
    public void FadeIn()
    {
        Color _spriteColor = m_spriteRenderer.color;            // ���݂�RGBA���擾
        float _duration = 1.0f;                                 // �t�F�[�h�ɂ����鎞��
        float _targetAlpha = 1.0f;                              // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a += _changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
    }

    //=============================================
    // �I�u�W�F�N�g���t�F�[�h�A�E�g
    //=============================================
    public void FadeOut()
    {
        Color _spriteColor = m_spriteRenderer.color;            // ���݂�RGBA���擾
        float _duration = 1.0f;                                 // �t�F�[�h�ɂ����鎞��
        float _targetAlpha = 0.0f;                              // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a > _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;    // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a -= _changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
        else
        {
            //m_deleteFg = true;  // �G�̍폜�t���O�𗧂Ă�
        }
    }
}
