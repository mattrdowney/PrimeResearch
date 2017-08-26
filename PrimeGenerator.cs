using UnityEngine;
using System.Collections;

public class PrimeGenerator : MonoBehaviour
{
	public static int[] primes = new int[1000000];
	
	public static void MakePrimesList (int length)
	{
		if(primes[0] == 2) return; //make sure we don't redundantly reproduce the list for every object
		
		int i = 3; //the number to be checked for primality
		int index = 1; //the storage index of the next prime
		int break_after_index = 0; //this is NOT the actual number
	
		int break_after = 2;
		int break_after_squared = 4;
		
		primes[0] = 2; //label the first prime numbers, necessary because of the squaring optimizations.
		primes[1] = 3;
		primes[2] = 5;
		
		for(i = 3; i <= length; i++) //i is the index of the current number being checked; has nothing to do with the other indexes.
		{
			bool prime = true; //considered prime until proven otherwise
			
			if(break_after_squared == i)
			{
				break_after_index++;
				
				int temp;
				
				temp = primes[break_after_index];
				break_after         = temp;
				break_after_squared = temp*temp;
				prime = false; //a prime squared is not prime... aka 2*2 is not prime 3*3 is not prime
			}
			if(prime)
			{
				int j = 0;
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
				}
			}
		}
	}
}