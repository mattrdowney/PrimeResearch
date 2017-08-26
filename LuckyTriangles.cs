using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LuckyTriangles : MonoBehaviour
{
	public int dimensions = 15485863; //15,485,863						
	public int number = 1;
	
	public Transform trans;
	
	public GameObject FalsePositive;
	public GameObject FalseNegative;
	public GameObject True;
	
	int num;
	int adder = 0;
	int prime_index = 0;
	
	bool prime_estimate = true;
	bool prime_actual   = true;
	bool move = false;
	
	Vector3 pos = Vector3.zero;
	
	LuckyStruct[] cont = new LuckyStruct[76]; //new LuckyStruct[35];
	
	void Start ()
	{	
		num = number;
			
		FetchPrimesList();
		
		cont[0] = new LuckyStruct(1,1,1); //a = 0*b + 1, c=1 
		cont[1] = new LuckyStruct(1,3,1);
		cont[2] = new LuckyStruct(1,5,1);
		cont[3] = new LuckyStruct(1,7,1);
		cont[4] = new LuckyStruct(1,9,1);
		cont[5] = new LuckyStruct(1,11,1);
		cont[6] = new LuckyStruct(1,13,1);
		cont[7] = new LuckyStruct(1,15,1);
		cont[8] = new LuckyStruct(1,17,1);
		cont[9] = new LuckyStruct(1,19,1);
		cont[10] = new LuckyStruct(1,21,1);
		cont[11] = new LuckyStruct(1,23,1);
		cont[12] = new LuckyStruct(1,25,1);
		cont[13] = new LuckyStruct(1,27,1);
		cont[14] = new LuckyStruct(1,29,1);
		cont[15] = new LuckyStruct(1,31,1);
		cont[16] = new LuckyStruct(1,33,1);
		cont[17] = new LuckyStruct(1,35,1);
		cont[18] = new LuckyStruct(1,37,1);
		cont[19] = new LuckyStruct(1,39,1);
		cont[61] = new LuckyStruct(1,41,1);
		cont[62] = new LuckyStruct(1,43,1);
		cont[63] = new LuckyStruct(1,45,1);
		cont[64] = new LuckyStruct(1,47,1);
		cont[65] = new LuckyStruct(1,49,1);
		cont[66] = new LuckyStruct(1,51,1);
		cont[67] = new LuckyStruct(1,53,1);
		cont[68] = new LuckyStruct(1,55,1);
		cont[69] = new LuckyStruct(1,57,1);
		cont[70] = new LuckyStruct(1,59,1);
		cont[71] = new LuckyStruct(1,61,1);
		cont[72] = new LuckyStruct(1,63,1);
		cont[73] = new LuckyStruct(1,65,1);
		cont[74] = new LuckyStruct(1,67,1);
		cont[75] = new LuckyStruct(1,69,1);
		
		//                        (1,3,1)
		cont[20] = new LuckyStruct(5,7,2); //b = a + 2, c=int
		cont[21] = new LuckyStruct(9,11,3);
		cont[22] = new LuckyStruct(13,15,4);
		cont[23] = new LuckyStruct(17,19,5);
		cont[24] = new LuckyStruct(21,23,6);
		cont[25] = new LuckyStruct(25,27,7);
		cont[26] = new LuckyStruct(29,31,8);
		cont[27] = new LuckyStruct(33,35,9);
		cont[28] = new LuckyStruct(37,39,10);
		cont[29] = new LuckyStruct(41,43,11);
		cont[30] = new LuckyStruct(45,47,12);
		cont[31] = new LuckyStruct(49,51,13);
		cont[32] = new LuckyStruct(53,55,14);
		cont[33] = new LuckyStruct(57,59,15);
		cont[34] = new LuckyStruct(57,59,15);
		cont[35] = new LuckyStruct(57,59,15);
		cont[36] = new LuckyStruct(57,59,15);
		cont[37] = new LuckyStruct(57,59,15);
		cont[38] = new LuckyStruct(57,59,15);
		cont[39] = new LuckyStruct(57,59,15);
		
		//                        (1,5,1)
		cont[40] = new LuckyStruct(7,17,3); 
		cont[41] = new LuckyStruct(13,29,5); //b = a*2 + 3, c=odd
		cont[42] = new LuckyStruct(19,41,7);
		cont[43] = new LuckyStruct(25,53,9);
		cont[44] = new LuckyStruct(31,65,11);
		cont[45] = new LuckyStruct(37,77,13);
		
		//                        (5,7,2)
		cont[46] = new LuckyStruct(11,19,4); 
		cont[47] = new LuckyStruct(17,31,6); //b = a*2 - 3, c=even
		cont[48] = new LuckyStruct(23,43,8);
		cont[49] = new LuckyStruct(29,55,10);
		cont[50] = new LuckyStruct(35,67,12);
		
		//                        (1,7,2)
		cont[51] = new LuckyStruct(9,31,4); //b = a*3 + 4
		cont[52] = new LuckyStruct(17,55,7);
		cont[53] = new LuckyStruct(25,79,10);
		
		//                        (7,17,3)
		cont[54] = new LuckyStruct(15,41,6); //b = a*3 - 4
		cont[55] = new LuckyStruct(23,65,9);
		//
		
		cont[56] = new LuckyStruct(11,49,5); //b = a*4 + 5 
		//
		
		cont[57] = new LuckyStruct(19,71,8); //b = a*4 - 5
		//
		
		cont[58] = new LuckyStruct(13,71,6); //b = a*5 + 6
		
		cont[59] = new LuckyStruct(29,41,9); //unknown
		cont[60] = new LuckyStruct(31,49,10);
		
		trans = this.gameObject.transform;
		
		InvokeRepeating("Generate2DValue",1,0.001f);
	}
	
	void Update ()
	{
		if(Input.GetButtonDown("Jump"))
		{
			Generate2DArray();	
		}
	}
	
	void FixedUpdate ()
	{
		if(Input.GetKey(KeyCode.Escape)) { Application.Quit(); }	
	}
	
	void FetchPrimesList ()
	{
		PrimeGenerator.MakePrimesList(dimensions);
	}
	
	void IsPrime()
	{
		prime_actual = false; // not prime until proven otherwise
		while (PrimeGenerator.primes[prime_index] <= num)
		{
			if(PrimeGenerator.primes[prime_index] == num) { prime_actual = true ; }
			prime_index++;
		}
	}
	
	void Spawn(Vector3 position)
	{
		GameObject obj = null;
		int resetter = adder/2;
		int temp = resetter;
		int s = 1;
		
		IsPrime(); //set prime_actual based on value look-up
		
		prime_estimate = true; //prime until proven otherwise
		
		if(temp >= number - 1)
		{
			temp -= (number - 1);
			if(S(s,temp)) prime_estimate = false;
			s++;
			if(temp % number <= 1) prime_estimate = false; //the best optimization (at least for low numbers) disproves 2 out of 3 of primes for 3, 2 out of 41 for 41
		}
		
		
		if(prime_estimate)
		{
			for(int i = 0; i < 76; ++i)
			{
				if(Sn(ref cont[i], resetter))
				{
					prime_estimate = false;
					break; //the number is composite, so stop
				}
			}
		}
		
		if(prime_actual != prime_estimate) 
		{
			if(!move) move = true;
			
			if(prime_actual)
			{
				obj = (GameObject)Instantiate(FalseNegative,position + Vector3.up,Quaternion.identity);
				if(obj) { obj.name = "Z-False Negative" + num.ToString(); }
			} //https://en.wikipedia.org/wiki/Type_I_and_type_II_errors#False_negative_error
			else 
			{
				obj = (GameObject)Instantiate(FalsePositive,position + Vector3.up,Quaternion.identity);
				if(obj) { obj.name = "Z-False Positive" + num.ToString() + ": " + resetter.ToString(); }
			} //https://en.wikipedia.org/wiki/Type_I_and_type_II_errors#False_positive_error
		}
		else if(move && prime_actual)
		{
			obj = (GameObject)Instantiate(True,position + Vector3.up,Quaternion.identity);
			if(obj) { obj.name = "Z-True          " + num.ToString(); }
		}
	}
	
	bool S(int z_gonal,int displacement)
	{
		float z = z_gonal; // s_gonal is 2*z_gonal + 2!  input of z=1 yields square (s=4); 2==hexagonal (6); 3==octagonal (8)
		float n = displacement;
		
		float temp1 = Mathf.Sqrt(n/z + .25f - .5f/z + .25f/(z*z)); //Last formula in "Formula" section simplified for s=(2z+2) : http://en.wikipedia.org/wiki/Polygonal_number#Formula
		float temp2 = (z-1)/(z+z); //might be irrelevant, but a previous version of this formula is strikingly similar to the quadratic equation
		
		return (Approximately(					temp1 + temp2,            // temp1 ± temp2 ≈ integer, ideally exact
									Mathf.Round(temp1 + temp2) ) ? true : 
			    Approximately(					temp1 - temp2,            // i.e. are either of the numbers even generalized s-gonal numbers?
									Mathf.Round(temp1 - temp2) ) );
	}
	
	bool S2(int z_gonal,int displacement)
	{
		float z = (float) z_gonal;
		float n = (float) displacement;
		
		float t1 = .125f/(1+z+z); // 1/(8+16z)
		float t2 = t1 + t1;       // 1/(4+8z)
		float t3 = t2 + t2;       // 1/(2+4z)
		
		float temp1 = Mathf.Sqrt((n+t1)*t3); 
		float temp2 = t2;
		
		return (Approximately(					temp1 + temp2,            // temp1 ± temp2 ≈ integer, ideally exact
									Mathf.Round(temp1 + temp2) ) ? true : 
			    Approximately(					temp1 - temp2,            // numbers of form A*x^2 - (A-1)*x
									Mathf.Round(temp1 - temp2) ) );
	}
	
	bool Sn(ref LuckyStruct s, int displacement)
	{
		float n = (float) displacement - ( s.Get_Mult() * number - s.Get_Shift() );
		
		if(n < 0) return false;
		
		float temp1 = Mathf.Sqrt( (n + s.Get_1() ) * s.Get_2() ); 
		float temp2 = s.Get_3();
		
		return (Approximately(					temp1 + temp2,            // temp1 ± temp2 ≈ integer, ideally exact
									Mathf.Round(temp1 + temp2) ) ? true : 
			    Approximately(					temp1 - temp2,            
									Mathf.Round(temp1 - temp2) ) );
	}
	
	void Generate2DArray ()
	{
		while(Generate2DValue());
	}
	
	bool Generate2DValue ()
	{
		if(num >= dimensions)
		{
			CancelInvoke("Generate2DValue");
			return false;
		}
		
		Spawn(pos + trans.position);
		
		adder  += 2;
		num += adder; //forms num + (triangular numbers)*2   aka   num + 0,2,6,12,20,30... 
		
		if(move) pos += Vector3.right;
		return true;
	}
	
	bool Approximately(float a, float b)
	{
		float temp = a - b;
		float eps = 0.00001f;
		
		if(-eps < temp && temp < eps) return true; //then within ten epsilons of error, therefore approximately equal to desired value of zero
		
		return false;
	}
}













//		while(temp >= number && prime_estimate && s < 100) // these while loops would be more efficient going in reverse order
//		{
//			temp -= number;
//			
//			if(S(s,temp)) prime_estimate = false;
//				
//			s++;
//		}
//		
//		
//		temp = (resetter - num*2 + 1);
//		s = 1;
//		while(temp >= (number*4 - 1) && prime_estimate && s < 100) // these while loops would be more efficient going in reverse order
//		{
//			temp -= (number*4 - 1);
//			
//			if(S2(s,temp)) prime_estimate = false;
//				
//			s++;
//		}