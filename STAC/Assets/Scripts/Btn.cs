using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
   public void Left()
   {
      FindObjectOfType<Rotate>().Left();
   }

   public void Right()
   {
      FindObjectOfType<Rotate>().Right();
   }
}
