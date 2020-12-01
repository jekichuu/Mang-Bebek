using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject enemyGroup1;
    public GameObject enemyGroup2;
    public GameObject enemyGroup3;
    public GameObject enemyGroup4;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public float bossHealth=4f;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("button")){
            bossHealth -= 1;
            float temp = bossHealth;
            Debug.Log("Asu");
            if (bossHealth == 3f)
            {
                Debug.Log("Asu2");
                Object.Destroy(enemyGroup1);
                enemyGroup2.SetActive(true);
                Debug.Log("Asu3");
            }
            if (bossHealth == 2f)
            {
                Object.Destroy(enemyGroup2);
                enemyGroup3.SetActive(true);
            }
            if (bossHealth == 1f)
            {
                Object.Destroy(enemyGroup3);
                enemyGroup4.SetActive(true);
            }
        }
    }
}
