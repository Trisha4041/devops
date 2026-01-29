using System.Security.Cryptography.X509Certificates;

namespace YCCECalc;

public class MyMaths
{
    public int add2nos(int a, int b)
    {
        if(a>0 && b>0)
        {
            return a + b;
        }
        else 
        {
            return 0;
        }
    }
}
