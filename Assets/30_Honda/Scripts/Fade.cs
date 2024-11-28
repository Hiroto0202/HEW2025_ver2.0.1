using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool m_isFadeIn = false;     // �t�F�[�h�C�����Ă��邩�ǂ���
    public bool m_isFadeOut = false;    // �t�F�[�h�A�E�g���Ă��邩�ǂ���
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
    // �I�u�W�F�N�g���t�F�[�h�C��
    //=============================================
    public void FadeIn(GameObject _newObj)
    {
        m_isFadeIn = true;
        SpriteRenderer _spriteRenderer = _newObj.GetComponent<SpriteRenderer>();
        Color _spriteColor = _spriteRenderer.color;             // ���݂�RGBA���擾
        _spriteColor.a = 0.0f;                                  // �����ɂ���

        float _duration = 0.5f;                                 // �t�F�[�h�ɂ����鎞��
        float _targetAlpha = 1.0f;                              // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a < _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a +=_changeSpeed;
            _spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_isFadeIn = true; // �t�F�[�h�C������
        }
    }

    //=============================================
    // �I�u�W�F�N�g���t�F�[�h�A�E�g
    //=============================================
    public void FadeOut(GameObject _newObj)
    {
        m_isFadeOut = true;
        SpriteRenderer _spriteRenderer = _newObj.GetComponent<SpriteRenderer>();
        Color _spriteColor = _spriteRenderer.color;             // ���݂�RGBA���擾

        float _duration = 0.5f;                                 // �t�F�[�h�ɂ����鎞��
        float _targetAlpha = 0.0f;                              // �ŏI�̃A���t�@�l

        // ���݂̃A���t�@�l���w�肳�ꂽ�l�łȂ���
        if (_spriteColor.a > _targetAlpha)
        {
            float _changeSpeed = Time.deltaTime / _duration;   // �����x�̕ω��l�����߂�

            // ���߂��ω��l���ƂɃA���t�@�l��ύX����
            _spriteColor.a -= _changeSpeed;
            _spriteRenderer.color = _spriteColor;
        }
        else
        {
            m_isFadeOut = false;    // �t�F�[�h�A�E�g����
        }
    }
}
