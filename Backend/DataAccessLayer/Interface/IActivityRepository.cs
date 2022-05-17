using DataAccessLayer.Model;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IActivityRepository
    {
        dynamic GetActivity(int StartPageNumber, int EndPageNumber);
    }
}
