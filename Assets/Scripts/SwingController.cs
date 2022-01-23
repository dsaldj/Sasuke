using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//障害物ブランコの操作（正方向)
public class SwingController : MonoBehaviour
{
    private float speedZ = 100;  //ブランコのz方向速度
    private float second = 2f;   //１回揺れるのにかかる時間
    private float time = 0f;     //時間計測様

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start(){
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 10f && time <= 30f) {
            //一定周期で揺れる
            float s = Mathf.Cos(time * Mathf.PI / second);
            this.rb.velocity = new Vector3(0, this.rb.velocity.y, speedZ * s / 50);
        }
    }
}
