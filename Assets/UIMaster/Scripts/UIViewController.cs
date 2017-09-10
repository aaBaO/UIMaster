using System;
using UnityEngine;

public class UIViewController : UIViewControllerInterface {

	public UIView view;
	public string viewPrefabPath;

	public void UIViewControllerDidLoad(){

		GameObject uiPrefab = GameObject.Instantiate(Resources.Load<GameObject>(viewPrefabPath));
		uiPrefab.transform.SetParent(UIMaster.Instance.UIRootContainer.transform, false);
		uiPrefab.transform.localPosition = Vector3.zero;
		uiPrefab.transform.localScale = Vector3.one;
		view = uiPrefab.GetComponent<UIView>();
		if(view == null){
			Debug.LogError("view cannot init !!!");
			return;
		}
		OnShowView();
	}

	public virtual void OnShowView(){
		view.gameObject.SetActive(true);
		view.ShowView();
	}

	public virtual void OnHideView(){
		view.gameObject.SetActive(false);
		view.HideView();	
	}

	public virtual void OnCloseView(){
		view.CloseView();	
		UnityEngine.GameObject.Destroy(view.gameObject);
	}

	public virtual void Destory(){
	}
}

