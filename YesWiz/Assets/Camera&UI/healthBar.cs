using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {

    DamageReceiver damageReceiver;
    Camera cameraToLookAt = null;
    Image healthImage;

    // Use this for initialization
    void Start () {
        cameraToLookAt = Camera.main;
        damageReceiver = gameObject.GetComponentInParent<DamageReceiver>();
        healthImage = GetComponent<Image>();
        //print(damageReceiver);
        //print(healthImage);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(cameraToLookAt.transform);
        healthImage.fillAmount = damageReceiver.getHealthAsPercentage();
    }
}
