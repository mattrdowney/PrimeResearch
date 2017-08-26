using UnityEngine;
using System.Collections;

public class LogCollision : MonoBehaviour
{	
	//public ulong identity;
	
	// Use this for initialization
	public void SetText (ulong num)
	{
		GameObject obj;
		TextMesh txt;
		obj = this.gameObject;
		txt = obj.GetComponent<TextMesh>();
		txt.text = num.ToString();
	}
	
//	void OnCollisionEnter (Collision collision)
//	{
//		string displayPhrase = "Hit: " /*+ collision.gameObject.LogCollision.identity.ToString()*/ + " against " + identity.ToString();
//		Debug.Log (displayPhrase);
//	}
}
