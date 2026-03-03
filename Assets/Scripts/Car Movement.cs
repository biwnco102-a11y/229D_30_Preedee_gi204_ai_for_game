using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float turnSpeed = 2f;
    public float changeDirectionTime = 3f;

    private float timer;
    private Quaternion targetRotation;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        // วิ่งไปข้างหน้าเสมอ
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // หมุนแบบ smooth ไปยังเป้าหมาย
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        // นับเวลาเพื่อเปลี่ยนทิศ
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            PickNewDirection();
            timer = 0f;
        }
    }

    void PickNewDirection()
    {
        float randomAngle = Random.Range(-90f, 90f); // หมุนซ้าย/ขวา
        targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + randomAngle, 0f);
    }
}
