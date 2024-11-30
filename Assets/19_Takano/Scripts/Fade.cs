using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    MoveEnemy m_moveEnemy;              
    SpriteRenderer m_spriteRenderer;        // �t�F�[�h����I�u�W�F�N�g
    public float m_duration = 1.0f;         // �t�F�[�h�ɂ����鎞��
    public bool m_fadeOutFg = false;        // �t�F�[�h�A�E�g���邩�ǂ���
    public bool m_completeFadeOut = false;  // �t�F�[�h�A�E�g�������������ǂ���
    public bool m_completeFadeIn = false;   // �t�F�[�h�C���������������ǂ���

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
    // �I�u�W�F�N�g���t�F�[�h�C��
    //=============================================
    public void FadeIn()
    {
        Color _spriteColor = m_spriteRenderer.color;    // ���݂�RGBA���擾
        float _targetAlpha = 1.0f;                      // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / m_duration;   // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a +=_changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_completeFadeIn = true;
        }
    }

    //=============================================
    // �I�u�W�F�N�g���t�F�[�h�A�E�g
    //=============================================
    public void FadeOut()
    {
        Color _spriteColor = m_spriteRenderer.color;    // ���݂�RGBA���擾
        float _targetAlpha = 0.0f;                      // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a > _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / m_duration;   // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a -= _changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_completeFadeOut = true;
        }
    }
}
