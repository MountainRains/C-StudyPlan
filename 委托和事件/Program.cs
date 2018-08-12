using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    class Cooler
    {
        public Cooler(float temperature)
        {
            Temperature = temperature;
        }

        public float Temperature { get; set; }
        public void OnTemperatureChanged(float newTemperature)
        {
            if(newTemperature > Temperature)
            {
                System.Console.WriteLine("Cooler: On");
            }
            else
            {
                System.Console.WriteLine("Cooler: Off");
            }
        }
    }
    class Heater
    {
        public Heater(float temperature)
        {
            Temperature = temperature;
        }

        public float Temperature { get; set; }
        public void OnTemperatureChanged(float newTemperature)
        {
            if(newTemperature < Temperature)
            {
                System.Console.WriteLine("Heater: On");
            }
            else
            {
                System.Console.WriteLine("Heater: Off");
            }
        }
    }
    /// <summary>
    ///   事件的声明
    /// </summary>
    public class EventThermostat
    {
        public class TemperatureArgs: System.EventArgs
        {
            public TemperatureArgs( float newTemperature)
            {
                NewTemperature = newTemperature;
            }
            public float NewTemperature { get; set; }
        }
        public event EventHandler<TemperatureArgs> OnTemperatureChange = delegate { };

        public float _CurrentTemperature { get; set; }
        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if(value != CurrentTemperature)
                {
                    _CurrentTemperature = value;
                    OnTemperatureChange?.Invoke(this,new TemperatureArgs(value));  //

                }
            }
        }
    }
    public class Thermostat
    {
        public Action<float> OnTemperatureChange { get; set; }

        public float _CurrentTemperature { get; set; }
        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if(value != CurrentTemperature)
                {
                    _CurrentTemperature = value;
                    OnTemperatureChange?.Invoke(value);  //C# 6.0  用于null检查

                }
            }
        }
    }
    class Program
    {
        public delegate void OnTemperatureChangeHandle(float param1);
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(60);
            Cooler cooler = new Cooler(80);
            string temperature;

            Action<float> delegate1;   //定义三个float输入，无返回的委托。Action用于简化委托的声明。
            Action<float> delegate2;   //等效于 public delegate void OnTemperatureChangeHandle(float param1);
            Action<float> delegate3;   //从下面可以看出 delegate3 和delegate4 起到了同样的效果
                                       //使用Action类可以有效地减少自己定义委托的麻烦，但是会导致可读性降低。

            OnTemperatureChangeHandle delegate4;
            OnTemperatureChangeHandle delegate5;
            OnTemperatureChangeHandle delegate6;
            


            delegate1 = heater.OnTemperatureChanged;
            delegate2 = cooler.OnTemperatureChanged;
            Console.WriteLine("Invoke both delegates: ");
            delegate3 = delegate1;
            delegate3 += delegate2;
            delegate3(90);

            delegate5 = heater.OnTemperatureChanged;
            delegate6 = cooler.OnTemperatureChanged;
            Console.WriteLine("Invoke by OnTemperatureChangeHandle: ");
            delegate4 = delegate5;
            delegate4 += delegate6;
            delegate4 += 
                x => { Console.WriteLine("Lambda with delegate test: {0}", x); }; //Lambda函数练习
            delegate4(90);


        /*
         * 在这里真正起到作用的是thermostat类中的CurrentTemperature属性中的set方法里
         * 调用OnTemperatureChange（value)
         * 更为安全和高级的在C# 6.0中我们使用OnTemperatureChange?.Invoke（value)
         * ? 是null条件操作符，可以检查委托订阅是否为null避免抛出一个异常。

        //    thermostat.OnTemperatureChange += heater.OnTemperatureChanged;  
        //    thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;

            Console.WriteLine("Enter temperature: ");
            temperature = Console.ReadLine();
            thermostat.CurrentTemperature = int.Parse(temperature);
        */
        }
    }
}
