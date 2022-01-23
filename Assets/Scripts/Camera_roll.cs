using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//タイトルシーンでカメラをUnitychanの周りで回転
public class Camera_roll : MonoBehaviour
{
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Unitychanを中心にカメラを回転
        transform.RotateAround(unitychan.transform.position, new Vector3(0, 1, 0), 0.15f);
    }
}
