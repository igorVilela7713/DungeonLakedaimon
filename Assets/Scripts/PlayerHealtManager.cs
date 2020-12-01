using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealtManager : MonoBehaviour{

    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive;
    public float flashLenght;
    private float flashCounter;

    private SpriteRenderer playerSprite;


    void Start(){
      playerCurrentHealth = playerMaxHealth;
      playerSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update(){
      if (playerCurrentHealth <= 0) {
      //  gameObject.SetActive (false);
        SceneManager.LoadScene("main");
        playerCurrentHealth = playerMaxHealth;
        gameObject.GetComponent<PlayerController>().startPoint = "Spawn";
      }

      if (flashActive) {

        if(flashCounter > flashLenght * 0.66f){
          playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
        }else if (flashCounter > flashLenght * 0.33f){
          playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
        }else if (flashCounter > 0f){
          playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
        }else{
          playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
          flashActive = false;
        }
        flashCounter -= Time.deltaTime;

      }

    }

    public void HurtPlayer(int damageToGive){

      playerCurrentHealth -= damageToGive;
      flashActive = true;
      flashCounter = flashLenght;

    }

    public void SetMaxHealth(){

      playerCurrentHealth = playerMaxHealth;

    }


}
