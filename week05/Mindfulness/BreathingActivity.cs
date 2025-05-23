using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public void Inhale()
    {
        List<string> inhale = new List<string>() { "[*              ]", "[**             ]", "[***            ]", "[****           ]", "[*****          ]", "[******         ]", "[*******        ]", "[********       ]", "[*********      ]", "[**********     ]", "[***********    ]", "[************   ]", "[*************  ]", "[************** ]", "[***************]" };
        foreach (string i in inhale)
        {
            Console.Write($"Breathe in  {i}");
            Thread.Sleep(400);
            Console.Write("\r");
        }
        Console.WriteLine();
    }

    public void Exhale()
    {
        List<string> exhale = new List<string>() { "[               ]", "[*              ]", "[**             ]", "[***            ]", "[****           ]", "[*****          ]", "[******         ]", "[*******        ]", "[********       ]", "[*********      ]", "[**********     ]", "[***********    ]", "[************   ]", "[*************  ]", "[************** ]", "[***************]" };
        exhale.Reverse();
        foreach (string i in exhale)
        {
            Console.Write($"Breathe out {i}");
            Thread.Sleep(400);
            Console.Write("\r");
        }
        Console.WriteLine();
    }


    public void Run()
    {
        DispaleyStartingMessage();
        setDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        Console.WriteLine("\n");
        while (DateTime.Now < futureTime)
        {
            Inhale();
            Exhale();
            Console.WriteLine("");
        }
        SaveToFile();
        DispaleyEndingMessage();
    }
}
