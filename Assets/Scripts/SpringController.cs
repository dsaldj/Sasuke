using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ジャンプ台(バネ)を縦振動させる
public class SpringController : MonoBehaviour {

    private Rigidbody rb;       //リジットボディ
    private float speedY = 8f;  //ジャンプ台のy方向速度
    private float second = 1f;　//振動周期
    private float time = 0f;    //時間計測用


    // Start is called before the first frame update
    void Start() {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //一定周期で縦振動させる
        time += Time.deltaTime;
        if (time >= 20f && time <= 30f) {
            float s = Mathf.Cos(time * Mathf.PI / second);
            this.rb.velocity = new Vector3(0, speedY * s, 0);
        }
    }
}