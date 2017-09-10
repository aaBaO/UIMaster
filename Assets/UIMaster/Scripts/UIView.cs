using System;
using UnityEngine;

public class UIView : MonoBehaviour, UIViewInterface {

	public virtual void InitView(){
		
	}

	public virtual void ShowView(){
		UnityEngine.Debug.Log("base UiView show view");	
	}

	public virtual void HideView(){
		UnityEngine.Debug.Log("base UiView hide view");	
	}

	public virtual void CloseView(){
		
	}
}

