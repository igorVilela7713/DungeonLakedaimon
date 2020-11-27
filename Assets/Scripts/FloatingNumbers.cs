using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour{
    // Start is called before the first frame update

    public float moveSpeed;
    public int damageNumber;
    public Text diplayNumber;

    void Start(){

    }

    // Update is called once per frame
    void Update() {

      diplayNumber.text = "" + damageNumber;
      transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);

    }
}
