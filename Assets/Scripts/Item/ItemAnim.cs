using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    public float rotationSpeed; 

    private void Update()
    {
        RotateItem();
    }

    void RotateItem()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
