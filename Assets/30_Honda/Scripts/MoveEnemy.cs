using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float m_elapsedTime = 0;            // Œo‰ßŽžŠÔ
    public float m_deleteTime = 5;      // ‰½•b‚½‚Á‚½‚çíœ‚·‚é‚©
    public bool m_deleteFg = false;     // íœ‚·‚é‚©‚Ç‚¤‚©

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        // íœ‚·‚é•b”‚É‚È‚Á‚½‚çƒtƒ‰ƒO‚ð—§‚Ä‚é
        if( m_elapsedTime >= m_deleteTime)
        {
            m_deleteFg = true;
            m_elapsedTime = 0;
        }

    }
}
