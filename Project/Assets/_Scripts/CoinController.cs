using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Coin Operations
    Last Modified: 15th April 2016
*/
public class CoinController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Destroy()
    {
        Destroy(gameObject);

    }
}
