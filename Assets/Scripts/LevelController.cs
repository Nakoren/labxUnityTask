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
    [SerializeField]
    private int max_hp = 3;
    private int currentScore=0;
    private int currentLife;

    public void OnEnable()
    {
        m_timer = 0;
        currentLife = max_hp;
    }
    public int Score { get { return currentScore; } }
    private void Update()
    {
        m_timer += Time.deltaTime;
        if(m_timer > m_delay)
        {
            spawner.Spawn();
            m_timer = 0;
        }
    }
}
