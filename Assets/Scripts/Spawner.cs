using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Segment _segmentTemplate;
    [SerializeField] Block _blockTemplate;
    [SerializeField] Finish _finishTemplate;
    [SerializeField] int _towerSize;

    void Start()
    {
        BuildTower();
    }

    private void BuildTower()
    {
        GameObject currentPoint = gameObject;
        
        for (int i = 0; i<_towerSize;i++)
        {
            currentPoint = BuildSegment(currentPoint, _segmentTemplate.gameObject);
            currentPoint = BuildSegment(currentPoint, _blockTemplate.gameObject);
        }
        BuildSegment(currentPoint, _finishTemplate.gameObject);
    }

    private GameObject BuildSegment(GameObject currentSegment, GameObject nextSegment)
    {
        return Instantiate(nextSegment, GetBuildPoint(currentSegment.transform, nextSegment.transform), Quaternion.identity, transform);
    }

    private Vector3 GetBuildPoint(Transform currentSegment, Transform nextSegment)
    {
        return new Vector3(transform.position.x, currentSegment.transform.position.y + currentSegment.localScale.y / 2 + nextSegment.localScale.y / 2, transform.position.y);
    }
}
