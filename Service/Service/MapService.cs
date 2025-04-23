using Domain.Entity;
using Domain.Enum;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MapService : IMap
    {
        private static List<Map> _map = new List<Map>();
        static int count = 0;

        public MapService()
        {
            if (_map == null)
            {
                _map = new List<Map>();
            }
        }

        public OpStatus Add(Map map)
        {
            try
            {

                if (!string.IsNullOrEmpty(map.PlaceName) && map.Latitude != 0 && map.Longitude != 0 && map.Latitude >= -90 && map.Latitude <= 90 && map.Longitude >= -180 && map.Longitude <= 180)
                {
                    var oldMapData = _map.Where(q => q.Latitude == map.Latitude && q.Longitude == map.Longitude).FirstOrDefault();
                    if (oldMapData == null)
                    {
                        count++;
                        map.Count = count;
                        _map.Add(map);

                        return OpStatus.Success;
                    }
                    return OpStatus.UserAlreadyExists;

                }
                else
                    return OpStatus.Error;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public OpStatus Delete(Guid id)
        {
            try
            {
                var map = _map.FirstOrDefault(q => q.Id == id);
                //var student = _students.Where(q => q.Id == id).FirstOrDefault();
                if (map != null)
                {
                   
                    _map.Remove(map);
                    return OpStatus.Success;
                }
                return OpStatus.UserNotFound;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Map? GetById(Guid id)
        {
            try
            {
                var map = _map.Where(q => q.Id == id).FirstOrDefault();
                if (map != null)
                {
                    return map;
                }
                return null; // id=0
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Map> List()
        {
            return _map;
        }

 
		public OpStatus Update(Map map)
		{
            try
            {
                
                int Count = map.Count;
                if (Count <= _map.Count) {
                    var oldMapData = _map[Count - 1];

                    if (map.PlaceName != null)
                        oldMapData.PlaceName = map.PlaceName;


                    oldMapData.Latitude = map.Latitude;
                    oldMapData.Longitude = map.Longitude;

                    return OpStatus.Success;

                }
                return OpStatus.Error;

            }
            catch (Exception)
            {

                throw;
            }
        }
	}

	
}
