using UnityEngine;
using System.Collections;

public class GeneratePrimes : MonoBehaviour
{
	ulong last_evaluated_number = 10000 + 1;
	public ulong[] primes = new ulong[10000]; //10K
	
	void MakePrimesList (ulong length)
	{
		uint i = 3; //the number to be checked for primality
		uint index = 1; //the storage index of the next prime 
		uint break_after_index = 0; //this is NOT the actual number
	
		ulong break_after = 2;
		ulong break_after_squared = 4;     
		
		primes[0] = 2; //label the first prime numbers, necessary because of the squaring optimizations.
		primes[1] = 3;
		primes[2] = 5;
		
		for(i = 3; i < length; i++) //i is the index of the current number being checked; has nothing to do with the other indexes.
		{
			if(break_after_squared == i)
			{
				break_after_index++;
				
				ulong temp;
				
				temp = primes[break_after_index];
				break_after         = temp;
				break_after_squared = temp*temp;
				
				continue; //a squared prime is not a prime, aka 2x2 = 4 !prime, 3x3 = 9 !prime
			}
			bool prime = true; //considered prime until proven otherwise
			uint j = 0;
			while(primes[j] <= break_after)
			{
				if(i % primes[j] == 0)
				{
					prime = false;
					break;
				}
				j++;
			}
			if(prime)
			{
				primes[index] = i;
				index++;
				//Debug.Log(i);
			}
		}
	}
	
	// Use this for initialization
	void Start ()
	{
	MakePrimesList(last_evaluated_number);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
