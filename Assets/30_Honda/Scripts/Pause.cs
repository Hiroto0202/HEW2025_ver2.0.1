using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_UIManager.m_pauseText.enabled = false;    // �ŏ��͕\�����Ȃ�
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I����
        if(m_countDown.m_countDownFg == false)
        {
            // �G�X�P�[�v�L�[�������ꂽ��
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0.0f;  // �Q�[�����~�߂�
                m_UIManager.m_pauseText.enabled = true;    // �|�[�Y�\��                                                                     

                // ������x�G�X�P�[�v�L�[�������ꂽ��
                if (Input.GetKeyDown(KeyCode.Escape)) 
                {
                    // UnityEditor�ł̎��s�Ȃ�Đ����[�h������
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    // �r���h��Ȃ�A�v���P�[�V�������I��
                    #else
                        Application.Quit();
                    #endif
                }
                // �o�b�N�X�y�[�X�������ꂽ��
                else if(Input.GetKeyDown(KeyCode.Backspace))
                {
                    m_UIManager.m_pauseText.enabled = false;    // �|�[�Y��\��
                    Time.timeScale = 1.0f;                     // �Q�[���ɖ߂�
                }
            }
        }
    }
}
