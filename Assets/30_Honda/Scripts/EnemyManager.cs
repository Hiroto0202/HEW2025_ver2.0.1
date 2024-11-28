using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject m_enemyPrefab;                        // �G�̃v���n�u
    GameObject m_newEnemy;                                  // �V�����������ꂽ�G
    List<GameObject> m_enemyList = new List<GameObject>();  // ���݂̓G�̃��X�g
    public int m_maxEnemyNum = 20;                          // �G�̍ő�o����
    public float m_searchFlagTime = 1;                      // ���b���ƂɃt���O�����������𒲂ׂ邩
    float m_elapsedTime = 0;                                // �o�ߎ���

    [Header("�G�̐����͈�")]
    public int m_minX = -8;
    public int m_maxX = 8;
    public int m_minY = -5;
    public int m_maxY = 5;

    CountDown m_countDown;
    Pause m_pause;
    Build m_build;
    Fade m_fade;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_pause = GetComponent<Pause>();
        m_build = GetComponent<Build>();
        m_fade = GetComponent<Fade>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_countDown.m_countDownFg == false && m_pause.m_pauseFg == false && m_build.m_buildFg == false)
        {
            m_elapsedTime += Time.deltaTime;    // �o�ߎ��Ԃ����߂�

            CreateEnemy();  // �ő�o�����܂œG���쐬����
            DeleteEnemy();  // �t���O�̗����Ă���G���폜����
        }

        // ���̃t�F�[�Y�Ɉڂ鎞�ɏ�����
        if(m_build.m_nextPhaseFg == true)
        {
            Init();
        }
    }

    //===========================================
    // ����������
    //===========================================
    public void Init()
    {
        // �G�����݂���ꍇ
        if (m_enemyList.Count > 0)
        {
            // ���ׂĂ̓G���폜����
            for (int _index = m_enemyList.Count - 1; _index >= 0; --_index)
            {
                Destroy(m_enemyList[_index]);
                m_enemyList.RemoveAt(_index);
            }
        }
    }

    //===========================================
    // �G�������_���Ȉʒu�ɍ쐬���鏈��
    //===========================================
    private void CreateEnemy()
    {
        // �G���ő�o������菭�Ȃ���
        if(m_enemyList.Count < m_maxEnemyNum )
        {
            // �t�F�[�h�C�����Ă��Ȃ���
            //if(m_fade.m_isFadeIn == false)
            {
                m_newEnemy = Instantiate(m_enemyPrefab);    // �G�𐶐�
                m_enemyList.Add(m_newEnemy);                // �G�����X�g�ɒǉ�
                // ���߂�ꂽ�͈͓��̃����_���Ȉʒu�ɂ���
                float _x = Random.Range(m_minX, m_maxX);
                float _y = Random.Range(m_minY, m_maxY);
                m_newEnemy.transform.position = new Vector2(_x, _y);
               // m_fade.FadeIn(m_newEnemy);  // �t�F�[�h�C���J�n
            }
            // �t�F�[�h�C�����Ă��鎞
            //else
            {
               // m_fade.FadeIn(m_newEnemy);  // �t�F�[�h�C���̂ݎ��s
            }

        }
    }

    //===========================================
    // �G���폜���鏈��
    //===========================================
    private void DeleteEnemy()
    {
        // �������ԂɂȂ�����
        if(m_elapsedTime >= m_searchFlagTime)
        {
            int _index = Random.Range(0, m_enemyList.Count);    // �폜����G�̓Y����������
            // �G�X�N���v�g���̍폜�t���O�������Ă��鎞
            if (m_enemyList[_index].GetComponent<MoveEnemy>().m_deleteFg == true)
            {
                m_fade.FadeOut(m_enemyList[_index]);    // �t�F�[�h�A�E�g�J�n
                // �t�F�[�h�A�E�g���Ă��鎞
                if(m_fade.m_isFadeOut == true)
                {
                    m_fade.FadeOut(m_enemyList[_index]);    // �t�F�[�h�A�E�g�̂ݎ��s
                }
                // �t�F�[�h�A�E�g�I����
                else
                {
                    // �G���폜����
                    Destroy(m_enemyList[_index]);
                    m_enemyList.RemoveAt(_index);
                    Debug.Log(_index + "�Ԗڂ��폜����");
                }
            }
            m_elapsedTime = 0;  // �o�ߎ��Ԃ����Z�b�g
        }
    }
}
