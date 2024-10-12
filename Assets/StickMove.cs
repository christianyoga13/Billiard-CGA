using UnityEngine;

public class StickMove : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan maju-mundur
    public float rotationSpeed = 100f;  // Kecepatan rotasi kiri-kanan
    public Transform whiteObject;  // Referensi ke objek "white"
    public float stopDistance = 0.6f;  // Jarak di mana stick berhenti agar tidak menabrak bola putih

    void Update()
    {
        // Kontrol maju-mundur menggunakan tombol W dan S atau panah atas dan bawah
        float moveDirection = Input.GetAxis("Vertical"); // W/S atau panah atas/bawah
        Vector3 directionToWhite = (whiteObject.position - transform.position).normalized;

        // Hitung jarak saat ini antara stick dan bola putih
        float currentDistance = Vector3.Distance(transform.position, whiteObject.position);

        // Hanya gerakkan stick maju jika jaraknya lebih besar dari stopDistance
        if (moveDirection < 0 || currentDistance > stopDistance)
        {
            transform.position += directionToWhite * moveDirection * moveSpeed * Time.deltaTime;
        }

        // Kontrol rotasi kiri-kanan menggunakan tombol A dan D atau panah kiri/kanan
        float rotateDirection = Input.GetAxis("Horizontal"); // A/D atau panah kiri/kanan
        transform.RotateAround(whiteObject.position, Vector3.up, rotateDirection * rotationSpeed * Time.deltaTime);
    }
}
