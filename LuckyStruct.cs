using UnityEngine;

public class LuckyStruct
{
	float c1;
	float c2;
	float c3;
	float multiple;
	float shift;
	//private float frequency
			
	public LuckyStruct(int a, int b, int shft)
	{
		int A  = (a+b)/2; // 'A' is the mean
		int B = A - a; //absolute distance between 'A' and either 'a' or 'b'
				
		if( A+A != a+b ) Debug.Log("'a+b' should be even: " + a + " " + b); //just in case
		
		c1 = 0.25f*B*B/A;
		c2 = 1f/A;
		c3 = 0.50f*B/A; //completing the square
		
		multiple = A;
		shift = shft;
	}
	
	public float Get_1() { return c1; }
	
	public float Get_2() { return c2; }
	
	public float Get_3() { return c3; }
	
	public float Get_Mult() { return multiple; }
	
	public float Get_Shift() { return shift; }
}
