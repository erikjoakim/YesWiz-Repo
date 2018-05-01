using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour {

    [Tooltip("The UI Canvas")]
    [SerializeField] Canvas enemyUICanvas=null;
    

    // Use this for initialization
	void Start () {

        Instantiate(enemyUICanvas, transform);
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
