using UnityEngine;
using System.Collections;

public class Field2D : MonoBehaviour
{
	GeneratePrimes generator;
	
	public ulong dimensions = 625;
	ulong[] primes = new ulong[10000];
	
	public GameObject prime;
	public GameObject nonPrime;
	
	Vector3 pos = Vector3.zero;
	
	bool started = false;
	
	void Start ()
	{
		GameObject obj = GameObject.Find("/Empty");
		generator = obj.GetComponent<GeneratePrimes>();
	}
	
	void Update ()
	{
	if(!started && Time.time > 1f)
		{
			FetchPrimesList();
			Generate2DField (dimensions);
			started = true;
		}
	}
	
	void FetchPrimesList ()
	{
		primes = generator.primes;	
	}
	
	void Generate2DField (ulong dim)
	{
		//bool skip = false;
		ulong number = 1;
		int size = 1;
		int counter = 0;
		bool change = false;
		int prime_index = 0;
		int up_right_down_left = 0;
		
		GameObject obj;
		LogCollision log;
		
		for(number = 1; number <= dim; number++)
		{
			if(number == primes[prime_index])
			{
				obj = (GameObject)Instantiate(prime,pos,Quaternion.identity);
				log = obj.GetComponentInChildren<LogCollision>();
				log.SetText(number);
				prime_index++;
			}
			else
			{
				obj = (GameObject)Instantiate(nonPrime,pos,Quaternion.identity);
				log = obj.GetComponentInChildren<LogCollision>();
				log.SetText(number);
			}
			
			if     (up_right_down_left == 0) pos += Vector3.forward;
			else if(up_right_down_left == 1) pos += Vector3.right;
			else if(up_right_down_left == 2) pos -= Vector3.forward;
			else                             pos -= Vector3.right;
			
			counter++;
			
			if(counter == size)
			{
				up_right_down_left++;
				if(up_right_down_left == 4) { up_right_down_left = 0; }
				if(change) { size++; }
				counter = 0;
				change = !change;
			}
			
			//if(Input.GetButton("Jump")) skip = true;
			
			//if(!skip) Idle();
		}
	}
	
	IEnumerator Idle()
	{
        yield return new WaitForSeconds(.99f);
    }

}
