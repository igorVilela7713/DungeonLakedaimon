using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour{

      public Slider healtBar;
      public Text HPText;
      public PlayerHealtManager playerHealt;
      private static bool UIExists;

    void Start(){

      if (!UIExists) {
        UIExists = true;
        DontDestroyOnLoad(transform.gameObject);
      }else{
        Destroy(gameObject);
      }

    }

    // Update is called once per frame
    void Update(){

      healtBar.maxValue = playerHealt.playerMaxHealth;
      healtBar.value = playerHealt.playerCurrentHealth;
      HPText.text = "HP: " + playerHealt.playerCurrentHealth + "/" + playerHealt.playerMaxHealth;

    }
}
