using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    public class Roles
    {
        public static Dictionary<string, Model.Roles> RolsList
        {
            get
            {
                return DAL.Roles.RolsList;
            }
        }

        public static bool Insert(Model.Roles model)
        {
            return DAL.Roles.Insert(model);
        }
        public static bool Update(Model.Roles model)
        {
            return DAL.Roles.Update(model);
        }

        /// <summary>
        /// 得到角色列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.Roles> GetList(string strWhere)
        {
            return DAL.Roles.GetList(strWhere);
        }


        /// <summary>
        /// 验证会用权限
        /// </summary>
        /// <param name="RType">角色类型</param>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static bool VerifyPower(Model.Member model, string url)
        {
            //if (RolsList.ContainsKey(model.Role.RType))
            //{
            //    if (RolsList[model.Role.RType].PowersList.Any(emp => !string.IsNullOrEmpty(emp.Content.CAddress) && url.ToUpper().Contains(emp.Content.CAddress.ToUpper())))
            //        return true;
            //}


            if (RolsList.ContainsKey(model.Role.RType))
            {
                if (!model.Role.IsAdmin)
                {
                    if (RolsList[model.Role.RType].PowersList.Any(emp => !string.IsNullOrEmpty(emp.Content.CAddress) && emp.Content.CAddress.ToUpper().Contains(url)) || RolsList[model.Role.RType].PowersList.Any(emp => !string.IsNullOrEmpty(emp.Content.OuterAddress) && (emp.Content.OuterAddress.ToUpper().Contains(url) || emp.Content.CAddress.ToUpper().Contains(url))))
                        //if (RolsList[model.Role.RType].PowersList.Any(emp => !string.IsNullOrEmpty(emp.Content.OuterAddress) && (emp.Content.OuterAddress.ToUpper().Contains(url) || emp.Content.CAddress.ToUpper().Contains(url))))
                        return true;
                }
                else
                {
                    if (RolsList[model.Role.RType].PowersList.Any(emp => !string.IsNullOrEmpty(emp.Content.CAddress) && emp.Content.CAddress.ToUpper().Contains(url)))
                        return true;
                }

            }


            //if (!BLL.Contents.List.Any(emp => !string.IsNullOrEmpty(emp.CAddress) && url.Contains(emp.CAddress.ToUpper())))
            //    return true;
            return false;
        }

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="RType">角色类型</param>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static bool VerifyUrl(string RType, string url)
        {
            if (RolsList.ContainsKey(RType))
            {
                foreach (Model.RolePowers item in RolsList[RType].PowersList)
                {
                    if (!string.IsNullOrEmpty(item.Content.CAddress) && (url.Contains(item.Content.CAddress.ToUpper()) || item.Content.CAddress.ToUpper().Contains(url)))
                        return item.IFVerify;
                    //if (!string.IsNullOrEmpty(item.Content.CAddress) && url.Contains(item.Content.CAddress.ToUpper()))
                    //    return item.IFVerify;
                }
            }
            return false;
        }

        /// <summary>
        /// 得到角色列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.Roles> GetRolesEntityList(string strWhere)
        {
            return DAL.Roles.GetRolesEntityList(strWhere);
        }

        public static Model.Roles GetModel(string id)
        {
            return DAL.Roles.GetModel(id);
        }
    }
}
