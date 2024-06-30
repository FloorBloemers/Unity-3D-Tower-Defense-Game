using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHitPoints = 5;
    Enemy enemy;
  
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = 5;
    }

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void ProcessHit() {
        currentHitPoints--;

        if (currentHitPoints <= 0) {
            gameObject.SetActive(false);
            enemy.RewardGold();
            enemy.RewardPoints();
        }
    }
}
