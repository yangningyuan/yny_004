using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.DAL
{
    public interface BaseData<T>
    {
        T GetModel(object obj);
        Hashtable Insert(T model, Hashtable MyHs);
        bool Insert(T model);
        Hashtable Update(T model, Hashtable MyHs);
        bool Update(T model);
        Hashtable Delete(object obj, Hashtable MyHs);
        bool Delete(object obj);
        DataTable GetTable(string strWhere);
        DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count);
        List<T> GetList(string strWhere);
        List<T> GetList(string strWhere, int pageIndex, int pageSize, out int count);
    }
}
