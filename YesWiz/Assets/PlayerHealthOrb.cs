using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerHealthOrb : MonoBehaviour {

    Image healthOrb;
    
    DamageReceiver damageReceiver;

    void Start()
    {
        damageReceiver = FindObjectOfType<Player>().GetComponent<DamageReceiver>();
        healthOrb = GetComponent<Image>();
        
    }
	
    void Update()
    {
        healthOrb.fillAmount = damageReceiver.getHealthAsPercentage();
    }

}
