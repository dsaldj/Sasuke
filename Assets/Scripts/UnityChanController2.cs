using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Unitychanの操作
public class UnityChanController2 : MonoBehaviour {

    Animator animator;　　　　　　　　　//unitychanのアニメーター
    private Rigidbody myrigidbody;   //リジットボディ
    private float jumpspeed = 10f;   //ジャンプ速度
    private bool is_Ground = false;　//地面（ステージ上)に着地しているかどうか

    private GameObject GoalText;　　　//ゴールテキスト
    private bool is_goal =false;　　　//ゴールしているかどうか

    private GameObject gameoverText;   //ゲームオーバーテキスト
    private bool is_gameover = false;  //ゲームオーバーになっているかどうか

    private float delta = 0;    　　　 //時間測定用の変数
    private GameObject TimeText;      //残り時間表示テキスト
    private float countdown = 30f;    //制限時間
    private float time;               //残り時間


    // スタート時に呼ばれる
    void Start() {
        this.animator = GetComponent<Animator>();
        this.myrigidbody = GetComponent<Rigidbody>();

        this.GoalText = GameObject.Find("GoalText");
        this.gameoverText = GameObject.Find("GameOverText");

        this.TimeText = GameObject.Find("TimeText");
        this.TimeText.GetComponent<Text>().text = "残り時間: " + countdown + "秒";
    }

    // フレーム毎に呼ばれる
    void Update() {
        this.delta += Time.deltaTime;
        
        //ゲームオーバーになっていない時
        if (is_gameover == false && is_goal == false) {

            // 上矢印キーで前進
            if (Input.GetKey("up")) {
                transform.position += transform.forward * 0.03f;
                animator.SetBool("is_running", true);
                
            }else {
                animator.SetBool("is_running", false);
                
            }

            // 左右矢印キーで左右回転
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(0, -0.5f, 0);
            }else if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(0, 0.5f, 0);
            }

            //spaceキーを押す、かつ接地状態でジャンプ
            if (Input.GetKeyDown(KeyCode.Space) && is_Ground == true) {
                is_Ground = false;
                this.animator.SetBool("is_jumping", true);
                
                //上方向に速度を与える。
                this.myrigidbody.velocity = new Vector3(0, jumpspeed, 0);
            }
            else {
                this.animator.SetBool("is_jumping", false);
            }


            // ゴールしていない時、テキストに残り時間を表示
            if (is_goal == false) {
                this.time = countdown - delta;
                this.TimeText.GetComponent<Text>().text = "残り: " + time.ToString("F1") + "秒";
            }
        }
        //リターンキーで操作説明シーンに遷移
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Explanation");
        }

    }

    void OnCollisionStay(Collision other) {
        //地面(ステージ)に接地している時
        if (other.gameObject.tag == "GroundTag") {
            is_Ground = true;
        }

        //ジャンプ台との衝突した時
        if (other.gameObject.tag == "SpringTag") {
            Vector3 force = new Vector3(0f, 20f, -10f);
            //斜め方向に力を加える
            myrigidbody.AddForce(force, ForceMode.VelocityChange);
        }

        //制限時間内かつゴールに到達できた時
        if (delta < 30f && other.gameObject.tag == "GoalTag") {
            is_goal = true;
            //Goalと表示
            this.GoalText.GetComponent<Text>().text = "Clear !!";
            // パーティクルを再生
            GetComponent<ParticleSystem>().Play();
        }
        //制限時間オーバーもしくはPlainオブジェクトに接地した時
        else if (time == 0f|| other.gameObject.tag == "PlainTag") {
            is_gameover = true;
            //テキストにゲームオーバーと表示
            this.gameoverText.GetComponent<Text>().text = "Game Over ";
        }
    }
}
