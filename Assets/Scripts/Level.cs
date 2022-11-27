using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float minFindDistance;
    public Transform[] protestors;

    public Transform currentProtestor;

    public static Level Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (PlayerCharacter.Instance == null) return;
        currentProtestor = FindNearByProtestors(Level.Instance.protestors);
        if (currentProtestor != null)
        {

        }
    }


    private Transform FindNearByProtestors(Transform[] protestors)
    {
        Transform tMin = null;
        float minDist = Level.Instance.minFindDistance;

        Vector3 currentPos = PlayerCharacter.Instance.transform.position;
        foreach (var t in protestors)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        return tMin;

    }

}
