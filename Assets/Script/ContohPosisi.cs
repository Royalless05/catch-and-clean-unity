using UnityEngine;

public class ContohPosisi : MonoBehaviour
{
    [SerializeField] private float kecepatan = 2f;
    // void Start(){
    //     // menetapkan kedudukan awal, dijalankan 1 kali
    //     transform.position = new Vector3(3f, 2f, 0f);
    // }

    void Update()
    {
        // mengeser objek pada sumbu x sebanyak 2 setiap frame
            // sumbu y dan z tidak ada perubahan karena ditambah 0f
        transform.Translate(0f, kecepatan * Time.deltaTime, 0f);
    }
}
