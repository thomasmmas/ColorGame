using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitialization : MonoBehaviour
{
   public TMPro.TextMeshProUGUI textElement;
   public UnityEngine.UI.Image imageElement;

   private void Awake()
   {
		InitializeUI();
   }

   private void InitializeUI()
   {
		  if(textElement != null)
		  {
				textElement.text = "Welcome to the Game!";
		  }
		  if (imageElement != null)
		  {

		  }
   }
}
