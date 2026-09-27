using UnityEngine;

public class PelotaRebotando : MonoBehaviour
{
    public int numeroRebotes = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            numeroRebotes++;
            Debug.Log("Rebote número: " + numeroRebotes);
        }
        
    }
}