using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Enemy Control, Movement and Animation
    Last Modified: 15th April 2016
*/
public class EnemyController : MonoBehaviour
{

    // Public Variables
    public float speed = 10f;

    // Private Variables
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Animator _animator;
    private bool isDead;

    // Use this for initialization
    void Start()
    {
        this._animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator CallDestroy()
    {
        Debug.Log("Call destroy");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        
    }

    public void Death()
    {
        Debug.Log("call death");
        _animator.SetInteger("AnimState", 1);
        StartCoroutine("CallDestroy");
    }




}
