using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Computer
    {
        private ComputerInfo computerInformation;
        private String model;
        private String manufacturer;

        public class ComputerInfo
        {
            public enum OperationSystem { MS, Linux, MacOS };
            private OperationSystem os;
            private string processor;
            private int ram;

            public ComputerInfo()
            {
            }

            public ComputerInfo(OperationSystem operatingSystem, string processor, int ram)
            {
                this.os = operatingSystem;
                this.processor = processor;
                this.ram = ram;
            }

            public OperationSystem OS { get => os; set => os = value; }
            public string Processor { get => processor; set => processor = value; }
            public int Ram { get => ram; set => ram = value; }

            public override bool Equals(object obj)
            {
                var info = obj as ComputerInfo;
                return info != null &&
                       OS == info.OS &&
                       Processor == info.Processor &&
                       Ram == info.Ram;
            }

            public override int GetHashCode()
            {
                var hashCode = 536699003;
                hashCode = hashCode * -1521134295 + OS.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Processor);
                hashCode = hashCode * -1521134295 + Ram.GetHashCode();
                return hashCode;
            }

            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append("Operation System = " + OS + ", ");
                str.Append("Processor = " + Processor + ", ");
                str.Append("RAM = " + Ram + "GB");
                return str.ToString();
            }
        }

        public Computer()
        {
        }

        public Computer(string model, string manufacturer, ComputerInfo computerInformation)
        {
            ComputerInformation = computerInformation;
            Model = model;
            Manufacturer = manufacturer;
        }

        public ComputerInfo ComputerInformation { get => computerInformation; set => computerInformation = value; }
        public string Model { get => model; set => model = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }

        

        public override string ToString()
        {
            return "Computer: { " + Manufacturer + " " + Model + ", " + ComputerInformation + " }";
        }

        public override bool Equals(object obj)
        {
            var computer = obj as Computer;
            return computer != null &&
                   ComputerInformation.Equals(computer.ComputerInformation) &&
                   Model == computer.Model &&
                   Manufacturer == computer.Manufacturer;
        }

        public override int GetHashCode()
        {
            var hashCode = 2065106944;
            hashCode = hashCode * -1521134295 + EqualityComparer<ComputerInfo>.Default.GetHashCode(ComputerInformation);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            return hashCode;
        }
    }
}
