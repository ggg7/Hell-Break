using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MeleeWeapon : MonoBehaviour {

     public float fireRate = 2;
     
     public string[] comboParams;
     private int comboIndex = 0 ;
     private Animator animator;
     private float resetTimer;
    public AudioClip laserSound;
    public AudioSource soundSource;
    void Awake()
     {
         if( comboParams == null || (comboParams != null && comboParams.Length == 0))
             comboParams = new string[]{"MeleeAttack1", "MeleeAttack2", "MeleeAttack3" };
         
         animator = GetComponent<Animator>() ;
         soundSource.clip = laserSound;
    }
     void Update()
     {
         if ( Input.GetButtonDown( "Fire1" ) && comboIndex < comboParams.Length )
         {
             soundSource.Play();
             Debug.Log( comboParams[comboIndex] + " triggered" );
             animator.SetTrigger( comboParams[comboIndex] );
             
             // If combo must not loop
             comboIndex++;
             
             // If combo can loop
             // comboIndex = (comboIndex + 1) % comboParams.Length ;
             
             resetTimer = 0f;
         }
         // Reset combo if the user has not clicked quickly enough
         if ( comboIndex > 0 )
         {
             resetTimer += Time.deltaTime;
             if ( resetTimer > fireRate )
             {
                 animator.SetTrigger( "Reset" );
                 comboIndex = 0;
             }
         }
     }
}