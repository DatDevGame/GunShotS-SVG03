using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGolemUp : MonoBehaviour
{
    public GameObject skillPrefabs;
    public GameObject circleRedPrefabs;
    public GameObject skillTwoPreofabs;
    protected GameObject target;
    protected float randPosSkillX;
    protected float randPosSkillY;
    private void Awake()
    {
        target = GameObject.Find("Player");

    }
    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        randPosSkillX = Random.Range(-0.5f, 0.5f);
        randPosSkillY = Random.Range(-0.5f, 0.5f);

        
    }

    protected virtual void spawnCircleRed()
    {
        Instantiate(circleRedPrefabs, new Vector2(target.transform.position.x + randPosSkillX, target.transform.position.y + randPosSkillY), Quaternion.identity);
        Instantiate(skillPrefabs, new Vector2(target.transform.position.x + randPosSkillX, (target.transform.position.y + randPosSkillY) + 0.3f), Quaternion.identity);
    }
}
