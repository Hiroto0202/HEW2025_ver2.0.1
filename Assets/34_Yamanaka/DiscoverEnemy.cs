using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverEnemy : MonoBehaviour
{
    public int m_enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {            
        if (other.transform.tag == "Enemy")
        {
            m_enemyCount++;
            Debug.Log("Enemy”­Œ©");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            m_enemyCount--;
        }
    }

}
