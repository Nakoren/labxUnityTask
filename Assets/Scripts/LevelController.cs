using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public Boulder_spawner spawner;
    private float m_timer;
    [SerializeField]
    private float m_delay = 2f;

    public void OnEnable()
    {
        m_timer = 0;
    }
    private void update()
    {
        m_timer += Time.deltaTime;
        if(m_timer > m_delay)
        {
            spawner.Spawn();
            m_timer = 0;
        }
    }
}
