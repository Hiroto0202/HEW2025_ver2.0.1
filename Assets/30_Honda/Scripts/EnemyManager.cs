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
    public bool m_fadeOutFg;
    int m_index = 0;        // �G�̓Y����

    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_pause = GetComponent<Pause>();
        m_build = GetComponent<Build>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_countDown.m_countDownFg == false && m_pause.m_pauseFg == false && m_build.m_buildFg == false)
        {
            m_elapsedTime += Time.deltaTime;    // �o�ߎ��Ԃ����߂�

            if(cnt < m_maxEnemyNum)
            {
                CreateEnemy();  // �ő�o�����܂œG���쐬����
                cnt++;
            }
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
            m_newEnemy = Instantiate(m_enemyPrefab);    // �G�𐶐�
            m_enemyList.Add(m_newEnemy);                // �G�����X�g�ɒǉ�

            // ���߂�ꂽ�͈͓��̃����_���Ȉʒu�ɂ���
            float _x = Random.Range(m_minX, m_maxX);
            float _y = Random.Range(m_minY, m_maxY);
            m_newEnemy.transform.position = new Vector2(_x, _y);
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
            m_index = Random.Range(0, m_enemyList.Count);    // �폜����G�̓Y����������
            MoveEnemy _moveEnemy = m_enemyList[m_index].GetComponent<MoveEnemy>();
            Fade _fade = m_enemyList[m_index].GetComponent<Fade>();

            // �G�X�N���v�g���̍폜�t���O�������Ă��鎞
            if (_moveEnemy.m_deleteFg == true)
            {
                _fade.m_fadeOutFg = true;       // �t�F�[�h�A�E�g������
                //Debug.Log(m_index);
            }

            // �t�F�[�h�A�E�g������������
            if (_fade.m_completeFadeOut == true)
            {
                // �G���폜����
                Destroy(m_enemyList[m_index]);
                m_enemyList.RemoveAt(m_index);
                //Debug.Log(m_index + "�Ԗڂ��폜����");
            }
            m_elapsedTime = 0;  // �o�ߎ��Ԃ����Z�b�g
        }
    }
}
