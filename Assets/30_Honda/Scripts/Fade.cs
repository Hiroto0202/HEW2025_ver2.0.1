using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    MoveEnemy m_moveEnemy;              
    SpriteRenderer m_spriteRenderer;    // �t�F�[�h����I�u�W�F�N�g

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
        Color _spriteColor = m_spriteRenderer.color;            // ���݂�RGBA���擾
        float _duration = 1.5f;                                 // �t�F�[�h�ɂ����鎞��
        float _targetAlpha = 1.0f;                              // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a +=_changeSpeed;
            m_spriteRenderer.color = _spriteColor;
        }
    }

    //=============================================
    // �I�u�W�F�N�g���t�F�[�h�A�E�g
    //=============================================
    public void FadeOut()
    {
        Color _spriteColor = m_spriteRenderer.color;            // ���݂�RGBA���擾
        float _duration = 1.5f;                                 // �t�F�[�h�ɂ����鎞��
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
            m_moveEnemy.m_deleteFg = true;  // �G�̍폜�t���O�𗧂Ă�
        }
    }
}
