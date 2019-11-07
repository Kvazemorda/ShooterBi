using System.Collections;
using UnityEngine;

public class CloserScript : MonoBehaviour
{   private Vector3 defPosition, newPosition;
    private float startTime, finishTime;
    public bool isClosing, isMovingToDefult;

    private void Start()
    {
        defPosition = transform.localPosition;
        Initalize();
    }

    private void Update()
    {
        if (isClosing)
        {
            startTime += Time.deltaTime * 6;
            CloseAim();
            if (startTime / finishTime >= 1)
            {
                isClosing = false;
                Initalize();
            }
        }
        if (isMovingToDefult)
        {
            transform.localPosition = defPosition;
            isMovingToDefult = false;
        }
    }

    private void Initalize()
    {
        finishTime = 2f;
        startTime = 0f;
    }
    public void CloseAim()
    {
        newPosition = new Vector3(0f, defPosition.y, defPosition.z);
        transform.localPosition = Vector3.Lerp(defPosition, newPosition, startTime/finishTime);
    }
}
