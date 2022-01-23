using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//障害物、岩オブジェクトのPrefabを生成
public class RockGenerator : MonoBehaviour
{
    public GameObject RockPrefab; //岩オブジェクトのPrefab
    private float delta = 0;      //時間測定用
    private float span = 1.0f;    //岩の生成間隔
    private float genPosX = 45;   //岩のx方向生成位置
    private float genPosY = 20f;  //岩のy方向生成位置

    private int maxBlockPos = 50;  //キューブz方向生成位置の上限


    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if (this.delta > this.span) {
            this.delta = 0;
            //生成する岩のz方向位置をランダムに決める
            int n = Random.Range(1, maxBlockPos );

                //岩オブジェクトの生成(出現位置はランダム)
                GameObject go = Instantiate(RockPrefab);
                go.transform.position =  new Vector3(genPosX, genPosY , 0.2f*n );
            
            //次の岩オブジェクトまでの生成時間を決める
            this.span = 2f ;

        }
    }
}
