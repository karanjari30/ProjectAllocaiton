using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ActivityRepository : IActivityRepository
    {
        public Karan_SatvaEntities objActivity = new Karan_SatvaEntities();
        public dynamic GetActivity(int StartPageNumber, int EndPageNumber)
        {
            return objActivity.GetActivity(StartPageNumber, EndPageNumber).ToList();
        }
    }
}
