using UnityEngine;

public class TestRandom : MonoBehaviour
{
    private System.Random random;
    private int seed = 2;

    private void Start()
    {
        random = new System.Random(seed);
        
        for(int i = 0; i <= 10; i++)
        {
            print(random.Next(1, 7));
        }
    }
}
