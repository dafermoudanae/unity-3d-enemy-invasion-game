using UnityEngine;

public class EnemiesMover : MonoBehaviour
{
    public float xStep = 1f;
    public float stepDelay = 0.15f;
    public int stepsRight = 8;
    public int stepsLeft = 16;
    public float yDrop = 2f;

    private float timer;
    private int phase = 0;
    private int stepCounter = 0;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < stepDelay) return;
        timer = 0f;

        switch (phase)
        {
            case 0:
                transform.position += new Vector3(+xStep, 0, 0);
                stepCounter++;
                if (stepCounter >= stepsRight) { phase = 1; stepCounter = 0; }
                break;

            case 1:
                ReturnToStartX(xStep);
                if (Mathf.Abs(transform.position.x - startPos.x) < 0.001f) { phase = 2; stepCounter = 0; }
                break;

            case 2:
                transform.position += new Vector3(-xStep, 0, 0);
                stepCounter++;
                if (stepCounter >= stepsLeft) { phase = 3; stepCounter = 0; }
                break;

            case 3:
                ReturnToStartX(xStep);
                if (Mathf.Abs(transform.position.x - startPos.x) < 0.001f) { phase = 4; }
                break;

            case 4:
                transform.position += new Vector3(0, -yDrop, 0);
                phase = 0;
                break;
        }
    }

    void ReturnToStartX(float step)
    {
        float xDifference = startPos.x - transform.position.x;

        if (Mathf.Abs(xDifference) <= step)
            transform.position = new Vector3(startPos.x, transform.position.y, transform.position.z);
        else
            transform.position += new Vector3(Mathf.Sign(xDifference) * step, 0, 0);
    }
}
