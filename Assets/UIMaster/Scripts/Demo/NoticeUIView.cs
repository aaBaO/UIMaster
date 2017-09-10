using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoticeUIView : UIView{
	public Button closeButton;
	public Button addButton;

	void Start(){
		closeButton.onClick.AddListener(()=> {
			UIMaster.Instance.Pop(UIMaster.Instance.noticeUIViewController);
		});

		addButton.onClick.AddListener(()=>{
			UIMaster.Instance.Push(UIMaster.Instance.mainUIViewController, UIType.Replace);
		});
	}

	public override void ShowView () {
		base.ShowView ();
	}

	public override void HideView () {
		base.HideView ();
	}

	public override void CloseView () {
		base.CloseView ();
	}
}

