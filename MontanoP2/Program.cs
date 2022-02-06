using System;

namespace MontanoP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gasNames = new string[100];
            double[] molecularWeights = new double[100];
            int count = 0;
            string gasName= "";
            string doAnother;
            
            
            ProgramHeader();
            DisplayHeader();
            GetMolecularWeight(ref gasNames,ref molecularWeights,out count);

            do
            {
                DisplayGasNames(gasNames, count);

                IdealGas gas = new IdealGas();
                double molecularWeight = GetMolecularWeightFromName(gasName, gasNames, molecularWeights, count);
                gas.SetMolecularWeight(molecularWeight);
                double volumeOfGas = double.Parse(GetInput("How much of the gas in meters cubed do you have?: "));
                gas.SetVolume(volumeOfGas);
                double tempCelcius = double.Parse(GetInput("At what temp is the gas held in celsius?: "));
                gas.SetTemp(tempCelcius);
                double massOfGas = double.Parse(GetInput("How many grams of the gas do you have?: "));
                gas.SetMass(massOfGas);

                Console.WriteLine(gas.GetSummary());

                Console.WriteLine("Would you like to try another gas? y/n ");
                doAnother = Console.ReadLine();

            } while (doAnother == "y");

            Console.WriteLine("\n\nThanks for testing out Montano Ideal Gas Calculator!\n           Have a fantasitc day!!   ");
        }



        private static void DisplayHeader()
        {
            Console.WriteLine("\n------------------------------------------------" +
                "\n\n Hello and welcome to the " +
                "Ideal Gas Calculator!" +
                "\n\n------------------------------------------------");
        }

        private static void ProgramHeader()
        {
            Console.WriteLine("\n Name: Andrew Montano" +
                "\n Program: MontanoP1 \n Objective: Get the pressure of " +
                "a given gas");
        }

        static void GetMolecularWeight(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            count = 0;


            foreach (string line in System.IO.File.ReadLines(@"MolecularWeightsGasesAndVaporsClasses.csv"))
            {
                //System.Console.WriteLine(line);
                string[] elements = line.Split(',');
                gasNames[count] = elements[0];
                molecularWeights[count] = double.Parse(elements[1]);
                count++;
            }


            //System.Console.WriteLine("There were {0} lines.", count);

        }

        private static void DisplayGasNames(string[] gasNames, int countGases)
        {
            for (int i = 0; i < countGases; i += 3)
            {
                Console.WriteLine(String.Format("{0,-20:D}", gasNames[i]) + "\t" + String.Format("{0,-20:D}", gasNames[i + 1]) + "\t" + String.Format("{0,-20:D}", gasNames[i + 2]));
            }
            
        }

        private static double GetMolecularWeightFromName(string gasName, string[] gasNames, double[] molecularWeights, int countGases)
        {
            Console.WriteLine("\n Please choose a gas from the list above (type out full name of gas as you see it): ");
            gasName = Console.ReadLine();
            var stringToFind = gasName;
            var result = Array.IndexOf(gasNames, stringToFind);
            if (result == -1)
            {
                Console.WriteLine("\n Check spelling of the gas you chose.");
            }
            else
            {
                Console.WriteLine("\n The gas you chose is " + gasName + " and has a molecular weight of " + molecularWeights[result] + " grams per mole!\n");
            }
            return molecularWeights[result];

        }

        private static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }


    }
}