//1. using system
//2. namespace. inside public class Dachi. inside pcD, set get; set;
//3. method dachi: start with the start values for the variables
using System;

namespace Dojodachi
{
    public class Dachi
    {
        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public int Meals { get; set; }
        public string Message { get; set; }

        public Dachi()
        {
            Fullness = 20;
            Happiness = 20;
            Energy = 50;
            Meals = 3;
        }
        public void Feed()
        {
            Meals = Meals - 1;
            Random rand = new Random();
            if(rand.Next(1,4) !=1)
            {
                Fullness = Fullness + rand.Next(5,10);
            }
           
        }
        public void Play()
        {
            Energy = Energy - 5;
            Random rand = new Random();
            if(rand.Next(1,4) !=1 )
            {
               Happiness = Happiness + rand.Next(5,10); 
            }
            
        }
        public void Work()
        {
            Energy = Energy - 5;
            Random rand = new Random();
            Meals = Meals + rand.Next(1,3);
        }
        public void Sleep()
        {
            Energy = Energy + 15;
            Fullness = Fullness - 5;
            Happiness = Happiness - 5;
        }

        // public void Total()
        // {
        //     if(Energy+Fullness+Happiness>=100)
        //     {
        //         Message="You Win!";
        //         //also need to display Restart button w/ this happening
        //     }
        //     if(Fullness==0 || Happiness==0)
        //     {
        //         Message="You Lose!";
        //         //also needs a restart button to display
        //     }
        // }

    }
}
