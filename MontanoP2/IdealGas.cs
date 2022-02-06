using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontanoP2
{
    internal class IdealGas
    {

        private double mass;
        public double GetMass()
        {
            return mass;
        }
        public void SetMass(double mass)
        {
            this.mass = mass;
            PresCalc();
        }

        private double volume;
        public double GetVolume()
        {
            return volume;
        }
        public void SetVolume(double volume)
        {
            this.volume = volume;
            PresCalc();
        }
        private double temp;
        public double GetTemp()
        {
            return temp;
        }
        public void SetTemp(double temp)
        {
            this.temp = temp;
            PresCalc();
        }
        private double molecularWeight;
        public double GetMolecularWeight()
        {
            return molecularWeight;
           
        }
        public void SetMolecularWeight(double molecularWeight)
        {
            this.molecularWeight = molecularWeight;
            PresCalc();
        }
        private double pressure;
        public double GetPressure()
        {
            return pressure; 
        }
        public string GetSummary()
        {
            return "----------------------------------------------------------------------------" +
                "\nPressure in Pascals: " + GetPressure() + " at " + temp + " degrees celcius. " +
                "\n----------------------------------------------------------------------------";
        }
        private void PresCalc()
        {
            pressure = ((mass / molecularWeight) * 8.3145 * (temp + 273.15)) / volume;
        }

                
        
    }

}
