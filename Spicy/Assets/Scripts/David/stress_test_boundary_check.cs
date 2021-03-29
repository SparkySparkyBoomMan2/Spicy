using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stress_test_boundary_check : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        Debug.Log("Passed boundary ");
    }
}
