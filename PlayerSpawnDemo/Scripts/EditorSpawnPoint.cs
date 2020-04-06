using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSpawnPoint : MonoBehaviour
{
    private MeshRenderer m_rend;
    void Awake()
    {
        m_rend = GetComponent<MeshRenderer>();
        m_rend.enabled = false;
    }
}
