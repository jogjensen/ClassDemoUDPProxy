using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SensorModelLib.model;

namespace SensorREST.managers
{
    public class SensorManager
    {
        private static readonly List<SensorData> _datas = new List<SensorData>();
        // alternativt nummerering
        private static int Count = 0;

        
        public SensorManager()
        {
        }

        public IEnumerable<SensorData> Get()
        {
            return _datas;
        }

        public SensorData Get(int id)
        {
            return _datas.Find(sd => sd.Id == id);
        }

        // POST api/<SensorController>
        public void Post(SensorData data)
        {
            int nextID = (_datas.Count!=0)?_datas.Max(d => d.Id) + 1:1;
            data.Id = nextID;

            /*
             * alternativt 
             * data.Id = Count++;
             */

            _datas.Add(data);
        }
    }
}
