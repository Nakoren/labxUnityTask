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

    public HitSoundScript soundPlayer;

    public BombSpawner bombSpawner;

    public StickScript stick;

    private float m_timer;

    public LevelSettings levelSettings;

    public SoundResources sounds;

    private int currentScore=0;

    private int currentLife;

    private List<StoneScript> stones = new List<StoneScript>();

    public event Action onLose;

    public event Action<int> onScoreInc;

    public event Action<int> onLifeChange;



    public void OnEnable()
    {
        currentScore = 0; 
        Debug.Log("Enabled levCont");
        m_timer = 0;
        currentLife = levelSettings.maxHp;
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
        if(m_timer > levelSettings.spawnDelay)
        {
            int randomNumber = UnityEngine.Random.Range(0, 100);
            //Debug.Log(randomNumber);
            if (randomNumber < levelSettings.bombChance)
            {
                //Debug.Log("Spawned bomb");
                BombScript newBomb = bombSpawner.Spawn().GetComponent<BombScript>();
                newBomb.onCollisionBomb += OnCollisionBomb;
                StartCoroutine(DestroyBomb(newBomb.gameObject));
            }
            else
            {
                //Debug.Log("Spawned stone");
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
        Debug.Log("OnCollisionStone");
        currentLife -= levelSettings.stoneHpLoss;
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
        soundPlayer.PlaySound(sounds.stoneHit);
        currentScore++;
        onScoreInc.Invoke(currentScore);
    }

    private void OnCollisionBomb()
    {
        Debug.Log("OnCollisionBomb");
        soundPlayer.PlaySound(sounds.explosion);
        currentLife -= levelSettings.bombHpLoss;
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
            GameInstance.NewBest = true;
        }
        GameInstance.lastScore = Score;
        Debug.Log($"Last score setted to {GameInstance.lastScore}");
        onLose?.Invoke();
    }
}