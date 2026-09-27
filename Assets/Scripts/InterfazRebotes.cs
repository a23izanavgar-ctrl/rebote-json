using TMPro;
using UnityEngine;

public class InterfazRebotes : MonoBehaviour
{
    public PelotaRebotando pelota;
    public TMP_Text textoRebotes;

    void Update()
    {
        textoRebotes.text = "Rebotes: " + pelota.numeroRebotes;
    }
}
