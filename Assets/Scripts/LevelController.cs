using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public StoneSpawner stoneSpawner;

    public BombSpawner bombSpawner;

    public StickScript stick;

    private float m_timer;

    [SerializeField]
    private float m_delay = 2f;

    [SerializeField]
    public int max_hp = 3;

    [SerializeField]
    public int bombChance = 30;

    private int currentScore=0;

    private int currentLife;

    private List<StoneScript> stones = new List<StoneScript>();

    public event Action onLose;

    public event Action<int> onScoreInc;

    public event Action<int> onLifeChange;


    public void OnEnable()
    {
        currentScore = 0; 
        currentLife = 3;
        Debug.Log("Enabled levCont");
        m_timer = 0;
        currentLife = max_hp;
        stick.onCollisionStone += OnCollisionStick;
    }

    private void OnDisable()
    {
        foreach (var st in stones)
        {
            Destroy(st.gameObject);
        }
        stones.Clear();
        if (stick != null)
        {
            stick.onCollisionStone -= OnCollisionStick;
        }
    }

    public int Score { get { return currentScore; } }
    public int Life { get { return currentLife; } }
    private void Update()
    {
        m_timer += Time.deltaTime;
        if(m_timer > m_delay)
        {
            int randomNumber = UnityEngine.Random.Range(0, 100);
            Debug.Log(randomNumber);
            if (randomNumber < bombChance)
            {
                Debug.Log("Spawned bomb");
                BombScript newBomb = bombSpawner.Spawn().GetComponent<BombScript>();
                newBomb.onCollisionBomb += OnCollisionBomb;
                StartCoroutine(DestroyBomb(newBomb.gameObject));
            }
            else
            {
                Debug.Log("Spawned stone");
                StoneScript newStone = stoneSpawner.Spawn().GetComponent<StoneScript>();
                newStone.onCollisionStone += OnCollisionStone;
                stones.Add(newStone);
            }
            m_timer = 0;
        }
    }

    private IEnumerator DestroyBomb(GameObject bomb)
    {
        yield return new WaitForSeconds(3);
        Destroy(bomb);
    }

    private void OnCollisionStone()
    {
        currentLife -= 1;
        if(currentLife <= 0)
        {
            Lose();
        }
        else
        {
            onLifeChange.Invoke(currentLife);
        }
    }
    private void OnCollisionStick()
    {
        currentScore++;
        onScoreInc?.Invoke(currentScore);
    }

    private void OnCollisionBomb()
    {
        currentLife -= 1;
        if (currentLife <= 0)
        {
            Lose();
        }
        else
        {
            onLifeChange.Invoke(currentLife);
        }
    }

    private void Lose()
    {
        stick.Down();
        Debug.Log("Game over");
        if (Score > GameInstance.bestScore)
        {
            GameInstance.bestScore = Score;
        }
        GameInstance.lastScore = Score;
        Debug.Log($"Last score setted to {GameInstance.lastScore}");
        onLose?.Invoke();
    }
}