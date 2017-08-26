using UnityEngine;
using System.Collections;

public class Field3D : MonoBehaviour
{
	public bool minimalist = false; //disable nonSpecial?
	//GenerateList generator;
	GeneratePrimes generator;
	
	ulong number = 1;
	int special_index = 0;
	public ulong dimensions = 3;
	ulong[] specialList = new ulong[10000];
	Vector3[] xyz;
	
	int cycle = 0;
	
	ulong[] size;
	
	public GameObject special;
	public GameObject nonSpecial;
	
	Vector3 pos = Vector3.zero;
	
	bool started = false;
	
	void Start ()
	{
		GameObject obj = GameObject.Find("/Empty");
		//generator = obj.GetComponent<GenerateList>();
		generator = obj.GetComponent<GeneratePrimes>();
		
		xyz = new Vector3[3];
		xyz[0] = Vector3.right;
		xyz[1] = Vector3.up;
		xyz[2] = -Vector3.forward; //Unity's positive z-axis is backwards! (reference: Right-Hand Rule)
		
		size = new ulong[3];
		size[0] = 1;
		size[1] = 1;
		size[2] = 1;
	}
	
	void Update ()
	{
		if(!started && Time.time > 1f)
		{
			FetchSpecialList();
			Generate3DField (1,9);
			started = true;
		}
	}
	
	void FetchSpecialList () //temporary
	{
		specialList = generator.primes;	
	}
	
	void Generate3DValue (ulong num)
	{
		//this should be the code
		//Generate Field should use a for-loop with this!!!
	}	
	
	int Instance(Vector3 position)
	{
		GameObject obj;
		LogCollision log;
		int temp = 0;
		
		if(number == specialList[special_index])
		{
			obj = (GameObject)Instantiate(special,position,Quaternion.identity);
			temp = 1;
		}
		else
		{
			obj = (GameObject)Instantiate(nonSpecial,position,Quaternion.identity);
		}
		
		//log = obj.GetComponent<LogCollision>();
		//log.SetText(number);
		
		return temp;
	}
	
	void Generate3DField (ulong start, ulong end)
	{	
		GameObject obj;
		LogCollision log;
		Vector3 last = Vector3.zero;
		bool unfinished = true;
		
		for(number = start; number <= end; number++)
		{
			special_index += Instance(pos);
			
			if(unfinished && number == 1)
			{
				pos -= Vector3.up;
				last = -Vector3.up;
				unfinished = false;
			}
			else if(number != (size[cycle] + 2)*(size[CheapMod3(cycle + 1)] + 2)*(size[CheapMod3(cycle + 2)]))
			{
				Debug.Log((size[cycle] + 2)*(size[CheapMod3(cycle + 1)] + 2)*(size[CheapMod3(cycle + 2)]));
				
			}
			
			//CROSS PRODUCTS HERE
			//IS THE ABS(CROSS) GREATER THAN .5?
			//IF SO, IS CROSS < 0--> Negative?
			
			//boundary exceeds size? if so do not call this quad group, instead check cross products
			
			if     (Vector3.Dot(pos,-xyz[cycle + 1]) <= 0) pos -= xyz[cycle + 1];
			else if(Vector3.Dot(pos, xyz[cycle + 1]) <= 0) pos += xyz[cycle + 1];
			else if(Vector3.Dot(pos,-xyz[cycle     ]) <= 0) pos -= xyz[cycle];
			else                                            pos += xyz[cycle];
		}
	}
	
	int CheapMod3(int dividend)
	{
		if(dividend == 3) return 0;
		if(dividend == 4) return 1;
		return dividend;
	}
	
	IEnumerator Wait()
	{
        yield return new WaitForSeconds(.2f);
    }
	
	//	void Generate3DStuff ()
//	{	
//		Vector3 p = Vector3.zero;
//		Vector3 Vector3_forward = -Vector3.forward;
//		
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.right; 
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p); //OTHER
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p -= Vector3.right;
//		Instance(p); //OTHER
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p -= Vector3.right;
//		Instance(p); //OTHER
//		p += Vector3_forward;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3.up;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p); //OTHER
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p);
//		p -= Vector3.right;
//		Instance(p);
//		p -= Vector3.right;
//		Instance(p);
//		p -= Vector3.right;
//		Instance(p);
//		p -= Vector3.right;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p -= Vector3_forward;
//		Instance(p);
//		p += Vector3.up;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3.right;
//		Instance(p);
//		p += Vector3_forward;
//		Instance(p); ///////////////////////////////KATSU/////////////////////////////////////////
//	}
	
//	bool LegalMove(Vector3 p,int c, bool b) //this is sort of irrelevant now that i think about it....
//	{
//		Vector3[] xyz;
//		xyz = new Vector3[3];
//		xyz[0] = Vector3.right;
//		xyz[1] = Vector3.up;
//		xyz[2] = -Vector3.forward; //Unity's positive z-axis is backwards! (reference: Right-Hand Rule)
//		
//		if(Vector3.Dot(p,-xyz[c + b]) <= 0 && Vector3.Cross()
//	}
}
