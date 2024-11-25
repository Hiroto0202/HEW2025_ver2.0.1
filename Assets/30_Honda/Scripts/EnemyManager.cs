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

    CountDown m_countDown;  // �J�E���g�_�E���X�N���v�g

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_countDown.m_countDownFg == false)
        {
            m_elapsedTime += Time.deltaTime;    // �o�ߎ��Ԃ����߂�

            CreateEnemy();  // �ő�o�����܂œG���쐬����
            DeleteEnemy();  // �t���O�̗����Ă���G���폜����
        }
    }

    //===========================================
    // ����������
    //===========================================
    private void Init()
    {
        m_enemyList.Clear();    // �G��S����
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
            int _index = Random.Range(0, m_enemyList.Count);    // �폜����G�̓Y����������
            // �G�X�N���v�g���̍폜�t���O�������Ă��鎞
            if (m_enemyList[_index].GetComponent<MoveEnemy>().m_deleteFg == true)
            {
                // �G���폜����
                Destroy(m_enemyList[_index]);
                m_enemyList.RemoveAt(_index);
                Debug.Log(_index + "�Ԗڂ��폜����");
            }
            m_elapsedTime = 0;  // �o�ߎ��Ԃ����Z�b�g
        }
    }
}
