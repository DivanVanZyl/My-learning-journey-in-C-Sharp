namespace ProjectEuler
{
    public class LargestPrimeFactor : ISolution
    {
        public string Run(long input)
        {
            long lpf = 0;
            for(long cnt = input/2;cnt > 3;cnt--)
            {
                if(input % cnt == 0)
                {
                    bool isPrime = true;
                    for(long i = 2;i < cnt;i++)
                    {
                        if(cnt % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if(isPrime)
                    {
                        lpf = cnt;
                        break;
                    }
                }
            }

            return lpf.ToString();
        }
    }
}
