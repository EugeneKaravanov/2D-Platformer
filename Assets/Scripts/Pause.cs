using System.Collections;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool IsPaused { get; private set; }

    public IEnumerator SetPause(float value)
    {
        IsPaused = true;
        yield return new WaitForSeconds(value);
        IsPaused = false;
    }
}
