using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Slider HPBar;
    private float enemyMaxHp = 10;
    public float enemyCurrntHp = 0;
    // Start is called before the first frame update
    void Start()
    {
        InitEnemyHP();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = enemyCurrntHp /enemyMaxHp;
    }

    private void InitEnemyHP()
    {
        enemyCurrntHp = enemyMaxHp;
    }
}
