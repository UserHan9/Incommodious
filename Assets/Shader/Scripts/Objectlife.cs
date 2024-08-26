using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectlife : MonoBehaviour
{
   public float lifetime;

   private IEnumerator DisableObjectCo()
   {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
   }

    private void OnEnable() 
   {
        StartCoroutine(DisableObjectCo()); 
   }
}
