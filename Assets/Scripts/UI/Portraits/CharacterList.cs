using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public static CharacterList instance = null;
    [SerializeField] List<CharacterStats> characters = new List<CharacterStats>();

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
