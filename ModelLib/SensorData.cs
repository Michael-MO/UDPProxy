using System;

namespace ModelLib
{
    public class SensorData
    {
        private int _id;
        private DateTime _time;
        private double _temp;

        public SensorData() { }

        public SensorData(int id, DateTime time, double temp)
        {
            ID = id;
            Time = time;
            Temperature = temp;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public double Temperature
        {
            get => _temp;
            set => _temp = value;
        }

        public override string ToString()
        {
            return $"id : {ID}, time : {Time}, Temp : {Temperature}";
        }
    }
}
