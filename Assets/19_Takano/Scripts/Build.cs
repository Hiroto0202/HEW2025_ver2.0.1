using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public UIManager m_UIManager;
    TimeLimit m_timeLimit;
    public bool m_buildFg;              // �r���h��ʂ��ǂ���
    public int m_phaseCnt = 0;          // ���t�F�[�Y�ڂ�
    public bool m_nextPhaseFg = false;
    //bool m_phaseUpdateFg = false;         // �t�F�[�Y���X�V���邩�ǂ���
    //bool m_ = false;       

    // Start is called before the first frame update
    void Start()
    {
        m_timeLimit = GetComponent<TimeLimit>();
        m_UIManager.m_buildText.enabled = false;    // �r���h���\��
    }

    // Update is called once per frame
    void Update()
    {
        // �������Ԃ��߂�����
        if(m_timeLimit.m_timeLimit <= 0)
        {
            m_buildFg = true;   // �r���h��ʂɂ���
        }

        // �r���h��ʂ̎�
        if(m_buildFg == true)
        {
            //Time.timeScale = 0.0f;  // �Q�[�����~�߂�
            m_UIManager.m_buildText.enabled = true; // �r���h��\��

            // �G���^�[�L�[�������ꂽ��
            if(Input.GetKeyDown(KeyCode.Return))
            {
                m_phaseCnt++;           // ���̃t�F�[�Y�ɂ���
                m_buildFg = false;      // �Q�[���ɖ߂�
                m_nextPhaseFg = true;   // ���̃t�F�[�Y�Ɉڂ�
            }
        }
        // �r���h��ʂłȂ���
        else
        {
            m_UIManager.m_buildText.enabled = false; // �r���h���\��
            //Time.timeScale = 1.0f;  // ���Ԃ�i�߂�
        }
    }

    public void GameInit()
    {
        m_timeLimit.Init();
    }
}