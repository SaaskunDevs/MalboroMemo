using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Indica que este scriptable object se puede crear desde el menú y especifica su nombre y archivo predeterminados
[CreateAssetMenu(menuName = "Information", fileName = "New Info")]
public class InfoCigarrette : ScriptableObject
{
    [SerializeField] int cigarretteIndex;
    [TextArea(2,6)] //Nos sirve para darle al usuario un minimo y limite
                    //De espacios de texto.
    [SerializeField] string infoCiga = "Enter new inbformation about cigarrette here";
    [SerializeField] Texture2D imgCigarrette; 
}
