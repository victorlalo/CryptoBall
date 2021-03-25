using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] ModuleSocket[] moduleLocations;

    void Start()
    {
        GenerateNewCharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateNewCharacter();
        }
    }

    void GenerateNewCharacter()
    {
        transform.rotation = Quaternion.Euler(0,140f,0);
        foreach(ModuleSocket mod in moduleLocations)
        {
            mod.GenerateNewModule();
        }
    }

    
}


// RNG Generation Methods:
// Option 1: Reference Prefabs of each piece
// Option 2: Load meshes into a Resource folder, and call names 