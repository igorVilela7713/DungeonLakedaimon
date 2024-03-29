﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour{

    // Start is called before the first frame update
    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    void Start(){

    }

    // Update is called once per frame
    void Update(){


    }

    void OnTriggerEnter2D(Collider2D other){

      if (other.gameObject.tag == "Enemy") {

        //  Destroy(other.gameObject);
        other.gameObject.GetComponent<EnemyHealtManager>().HurtEnemy(damageToGive);
        Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;

      }else if (other.gameObject.tag == "Boss") {

        //  Destroy(other.gameObject);
        other.gameObject.GetComponent<BossHealth>().TakeDamage(damageToGive);
        Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;

      }
    }
}
