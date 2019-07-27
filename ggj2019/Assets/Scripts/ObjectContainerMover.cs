using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainerMover : MonoBehaviour {

    [SerializeField] float m_speedFactor;
	
	// Update is called once per frame
	void Update () {
        DraggableItem[] childObjCList = GetComponentsInChildren<DraggableItem>();
        foreach (var childObjC in childObjCList)
        {
            float offset = m_speedFactor * Time.deltaTime;
            childObjC.transform.position -= new Vector3(0, offset, 0);
        }
	}

    public void SetSpeedFactor(float speed)
    {
        m_speedFactor = speed;
    }
}
