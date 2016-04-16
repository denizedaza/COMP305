using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Player Collision Detection and Interaction     ||Audio to be added
    Last Modified: 15th April 2016
*/
public class PlayerCollision : MonoBehaviour {

    public GameController gameController;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameController.damage(1);
            //EnemyController e = other.GetComponent<EnemyController>();
            //e.Death();
        }
        if (other.CompareTag("Coin"))
        {
            gameController.moneyUp(5);
            CoinController c = other.GetComponent<CoinController>();
            c.Destroy();
        }
    }
}
