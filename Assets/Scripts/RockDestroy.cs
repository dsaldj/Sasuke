using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//障害物岩オブジェクトを破壊
public class RockDestroy : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        float height = transform.position.y;
        //高さが1未満なったら破壊
        if (height < 1f) {
            Destroy(this.gameObject);
        }
    }
}
