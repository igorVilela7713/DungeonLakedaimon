using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtManager : MonoBehaviour{

    // Start is called before the first frame update

    public int maxHealth;
    public int currentHealth;


    void Start(){
      currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update(){
      if (currentHealth <= 0) {

        Destroy(gameObject);

      }

    }

    public void HurtEnemy(int damageToGive){

      currentHealth -= damageToGive;

    }

    public void SetMaxHealth(){

      currentHealth = maxHealth;

    }


}
