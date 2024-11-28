using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    Build m_build;
    public bool m_pauseFg = false;     // �|�[�Y�����ǂ���

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_build = GetComponent<Build>();
        m_UIManager.m_pauseText.enabled = false;    // �ŏ��͕\�����Ȃ�
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I���ォ�A�r���h��ʂłȂ��Ƃ�
        if(m_countDown.m_countDownFg == false && m_build.m_buildFg == false)
        {
            // �G�X�P�[�v�L�[�������ꂽ��
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                m_pauseFg = !m_pauseFg; // �|�[�Y���邩�ǂ���������
            }

            // �|�[�Y���鎞
            if(m_pauseFg == true)
            {
                Debug.Log("�|�[�Y��");
                //Time.timeScale = 0.0f;  // �Q�[�����~�߂�
                m_UIManager.m_pauseText.enabled = true;    // �|�[�Y�\��

                // �o�b�N�X�y�[�X�ŃQ�[���I��
                if (Input.GetKeyDown(KeyCode.Backspace))
                {

                    // UnityEditor�ł̎��s�Ȃ�Đ����[�h������
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    // �r���h��Ȃ�A�v���P�[�V�������I��
                    #else
                        Application.Quit();
                    #endif
                }
            }
            // �|�[�Y���Ȃ���
            else
            {
                Debug.Log("�|�[�Y����");
                //Time.timeScale = 1.0f;  // �Q�[����i�߂�
                m_UIManager.m_pauseText.enabled = false;    // �|�[�Y��\��
            }
        }
    }

    //===========================================================
    // ����������
    //===========================================================
    public void Init()
    {
        m_pauseFg = false;                          // �|�[�Y���Ȃ�
        m_UIManager.m_pauseText.enabled = false;    // �ŏ��͕\�����Ȃ�
    }
}
