using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List<float> numbers = new List<float>();
        int n;
        do {
            Console.Write("Enter a number: ");
            n = int.Parse(Console.ReadLine());
            if (n != 0){
                numbers.Add(n);
            }
            else{
                float sum = 0;
                float max = numbers[0];
                
                foreach(float number  in numbers){
                    sum = sum + number;
                    if (number > max){
                        max = number;
                    }
                }
                
                float average =  sum/numbers.Count(); 
                Console.WriteLine($"The list has {numbers.Count()} numbers.");  
                Console.WriteLine($"The total sum is {sum}.");  
                Console.WriteLine($"The average is {average}.");  
                Console.WriteLine($"The largest number is {max}.");  
                float min = max;
                if (max>=0){
                    foreach(float number in numbers)
                        if (number < min && number >0){
                                min = number;
                            }
                    Console.WriteLine($"The smallest positive number is: {min}."); 
                }
                else{
                    Console.WriteLine($"All numbers in the list are negative."); 
                }
                numbers.Sort(); 
                
                Console.WriteLine($"The sorted list is:"); 
                foreach (float number in numbers)
                {
                    Console.WriteLine(number);
                }
                 
            }
        }while (n!=0);
    }
    
}