using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGolemUp : MonoBehaviour
{
    Animator anim;

    public GameObject skillPrefabs;
    public GameObject circleRedPrefabs;
    public GameObject skillTwoPrefabs;
    public Transform posSkillTwo;
    protected GameObject target;
    protected float randPosSkillX;
    protected float randPosSkillY;

    protected float timer;
    protected float timeDuration;
    private void Awake()
    {
        posSkillTwo = transform.Find("PosSkillTwo");
        target = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }
    protected virtual void Start()
    {
        timeDuration = 20f;
        timer = timeDuration;
    }
    protected virtual void Update()
    {
        randPosSkillX = Random.Range(-3f, 3f);
        randPosSkillY = Random.Range(-3f, 3f);

        spawnSkillTwo();
    }

    protected virtual void spawnCircleRed()
    {
        Instantiate(circleRedPrefabs, new Vector2(target.transform.position.x + randPosSkillX, target.transform.position.y + randPosSkillY), Quaternion.identity);
        Instantiate(skillPrefabs, new Vector2(target.transform.position.x + randPosSkillX, (target.transform.position.y + randPosSkillY) + 0.3f), Quaternion.identity);
    }
    protected virtual void spawnCircleRedPlayer()
    {
        Instantiate(circleRedPrefabs, new Vector2(target.transform.position.x, target.transform.position.y), Quaternion.identity);
        Instantiate(skillPrefabs, new Vector2(target.transform.position.x, (target.transform.position.y) + 0.3f), Quaternion.identity);
    }

    protected virtual void spawnSkillTwo()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            anim.SetBool("GolemUpAttack2", true);
        }

    }
    protected virtual void skillTwo()
    {
        Instantiate(skillTwoPrefabs, posSkillTwo.position, Quaternion.identity);
        timer = timeDuration;
    }
    //set Anim 
    protected virtual void stopSkillTwo()
    {
        anim.SetBool("GolemUpAttack2", false);
    }
}
