//using UnityEngine;
//using System.Collections;
//
//public class Field3D : MonoBehaviour
//{
//	Vector3 p = Vector3.zero;
//	Vector3 Vector3_forward = new Vector3(0,0,-1); // remember x cross y is negative z cause Unity is backwards
//	public GameObject cube;
//	
//	// Use this for initialization
//	void Start ()
//	{
//	Generate3DField();
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//	
//	}
//	
//	void Generate3DField ()
//	{
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right; 
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity); //OTHER
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right;
//		Instantiate(cube,p,Quaternion.identity); //OTHER
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right;
//		Instantiate(cube,p,Quaternion.identity); //OTHER
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity); //OTHER
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p -= Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.up;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3.right;
//		Instantiate(cube,p,Quaternion.identity);
//		p += Vector3_forward;
//		Instantiate(cube,p,Quaternion.identity); ///////////////////////////////KATSU/////////////////////////////////////////
//	}
//}
//
////-J 
////-I 
//// J
//// J
//// I
//// I
////-J
////-J
//// K //OTHER
//// J
//// J
//// J
////-K
////-K
////-J
////-J
////-J
////-J
//// K
//// K
////-I //OTHER
//// J
//// J
//// J
//// J
////-K
////-K
////-J
////-J
////-J
////-J
//// K
////-I //OTHER
//// K
//// J
//// J
//// J
//// J
////-K
////-K
////-J
////-J
////-J
////-J
////-K //OTHER
//// I
//// I
//// I
//// K
//// K
//// K
//// K
////-I
////-I
////-I
////-I
////-K
////-K
////-K
////-K
//// J //OTHER
//// I
//// I
//// I
//// I
//// K
