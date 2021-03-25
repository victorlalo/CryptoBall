using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSocket : MonoBehaviour
{
    [SerializeField] GameObject[] prefabOptions;
    int optionsCount;

    GameObject currentSelection = null;
    int lastSelectionIdx = -1;

    void Start()
    {
        optionsCount = prefabOptions.Length;
    }

    public void GenerateNewModule()
    {
        if (currentSelection != null)
        {
            Destroy(currentSelection);
        }
        
        int selectionIdx = Random.Range(0, optionsCount);
        while (selectionIdx == lastSelectionIdx)
        {
            selectionIdx = Random.Range(0, optionsCount);
        }

        currentSelection = Instantiate(prefabOptions[selectionIdx], transform.position, transform.rotation, transform);

        lastSelectionIdx = selectionIdx;
    }
}
