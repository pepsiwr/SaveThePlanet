using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip jump;

    public static SoundManager Instance
    {
        get;
        set;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public AudioClip Jump
    {
        get
        {
            return jump;
        }
    }
}
