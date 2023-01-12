using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Parametrs")]
    public float StrengthHit;
    public float Defense;

    [HideInInspector] public bool IsGround;
    [HideInInspector] public bool IsHit = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("StrengthHit"))
        {
            StrengthHit = 1;
            PlayerPrefs.SetFloat("StrengthHit", StrengthHit);
        }

        StrengthHit = PlayerPrefs.GetFloat("Defense");

        if (PlayerPrefs.HasKey("Defense"))
        {
            Defense = 1;
            PlayerPrefs.SetFloat("Defense", Defense);
        }

        Defense = PlayerPrefs.GetFloat("Defense");
    }
}
