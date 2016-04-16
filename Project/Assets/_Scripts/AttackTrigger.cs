using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController e = other.GetComponent<EnemyController>();
            Debug.Log("attack");
            e.Death();
        }
    }
}
