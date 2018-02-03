using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;
using CommonModel;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Collections;

namespace yny_004.Web.Language
{
    public partial class Edit : BasePage
    {
        Sys_LanguageTypeBLL typeBll = new Sys_LanguageTypeBLL();
        protected override void SetPowerZone()
        {
            LanageList.DataSource = typeBll.GetModelList(" Status = 1 ");
            LanageList.DataTextField = "Name";
            LanageList.DataValueField = "Code";
            LanageList.DataBind();
        }

        protected override void SetValue(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Language = Sys_LanguageBLL.GetModel(id);
                //hidId.Value = id;
                //txtENName.Value = language.ENName;
                //txtZHName.Value = language.ZHName;
                //chkStatus.Checked = language.Status;
            }
        }

        private Sys_Language Language
        {
            get
            {
                Sys_Language model = null;
                if (string.IsNullOrEmpty(Request.Form["hidId"]))
                {
                    model = new Sys_Language();
                    model.Code = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "");
                    model.CreatedBy = TModel.MID;
                    model.CreatedTime = DateTime.Now;
                    model.IsDeleted = false;
                }
                else
                {
                    model = Sys_LanguageBLL.GetModel(Request.Form["hidId"]);
                    model.UpdatedBy = TModel.MID;
                    model.UpdatedTime = DateTime.Now;
                }
                model.ZHName = Request.Form["txtZHName"];
                model.ENName = Request.Form["txtENName"];
                model.Sort = 1;//string.IsNullOrEmpty(Request.Form["txtSort"]) ? 0 : long.Parse(Request.Form["txtSort"]);
                model.Status = !string.IsNullOrEmpty(Request.Form["chkStatus"]);
                model.LanguageCode = Request.Form["LanageList"];
                return model;
            }
            set
            {
                txtENName.Value = value.ENName;
                txtZHName.Value = value.ZHName;
                chkStatus.Checked = value.Status;
                hidId.Value = value.Id.ToString();
                LanageList.Value = value.LanguageCode;
            }
        }

        protected override string btnAdd_Click()
        {
            Sys_Language language = Language;
            if (language.ENName.Contains("\"") || language.ZHName.Contains("\""))
            {
                return "非法操作符(\")";
            }
            if (Sys_LanguageBLL.SaveOrUpdate(Language))
                return "操作成功";
            return "操作失败";
        }
        protected override string btnModify_Click()
        {
            string path = Request.Form["hidExcelPath"];
            string filePath = Server.MapPath("/Attachment/ImportExcel/" + path);
            string countInfo = ImportXlsToData(filePath);
            return countInfo;
        }

        ///<summary>
        /// 从Excel提取数据--》Dataset
        /// </summary>
        /// <param name="filename">Excel文件路径名</param>
        private string ImportXlsToData(string fileName)
        {
            string result = string.Empty;
            try
            {
                if (fileName == string.Empty)
                {
                    throw new ArgumentNullException("Excel文件上传失败！");
                }
                string oleDBConnString = "";
                if (fileName.ToLower().IndexOf(".xlsx") > 0)
                {
                    oleDBConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties='Excel 12.0;HDR=YES' IMEX=1";
                }
                else if (fileName.ToLower().IndexOf(".xls") > 0 && fileName.EndsWith("xls"))
                {
                    oleDBConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + fileName + "';Extended Properties='Excel 8.0;HDR=YES; IMEX=1'";
                }
                else
                {
                    throw new Exception("上传的不是Excel文件!");
                }
                OleDbConnection oleDBConn = new OleDbConnection(oleDBConnString);
                oleDBConn.Open();
                DataTable m_tableName = new DataTable();
                m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (m_tableName != null && m_tableName.Rows.Count > 0)
                {
                    m_tableName.TableName = m_tableName.Rows[1]["TABLE_NAME"].ToString();
                }
                string sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "]";
                OleDbDataAdapter oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
                DataSet ds = new DataSet();
                oleAdMaster.Fill(ds, "m_tableName");
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();
                result = AddDatasetToSQL(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 将Dataset的数据导入数据库
        /// </summary>
        /// <param name="pds">数据集</param>
        /// <param name="Cols">数据集列数</param>
        /// <returns></returns>
        private string AddDatasetToSQL(DataSet pds)
        {
            int totalCount = 0; //Excel中的总行数
            long realInport = 0;//实际导入数量
            int errors = 0; //导入出错数量
            int updateCount = 0, inserCount = 0;
            StringBuilder errInfo = new StringBuilder();  //导入出错信息

            IList<Sys_Language> qList = new List<Sys_Language>();
            DataTable dtExcel = pds.Tables[0];

            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {

                totalCount++;
                //保存题目
                Sys_Language objQ = new Sys_Language();
                objQ.Code = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "");
                if (string.IsNullOrEmpty(dtExcel.Rows[i][0].ToString().Trim()))
                {
                    errors++;
                    errInfo.Append("第【" + (i + 1).ToString() + "】行【" + dtExcel.Columns[0].ColumnName + "】单元格不能为空<br/>");
                }
                else
                {
                    objQ.ZHName = dtExcel.Rows[i][0].ToString();
                }

                if (string.IsNullOrEmpty(dtExcel.Rows[i][1].ToString().Trim()))
                {
                    errors++;
                    errInfo.Append("第【" + (i + 1).ToString() + "】行【" + dtExcel.Columns[1].ColumnName + "】单元格不能为空<br/>");
                }
                else
                {
                    objQ.ENName = dtExcel.Rows[i][1].ToString();
                }


                if (string.IsNullOrEmpty(dtExcel.Rows[i][2].ToString().Trim()))
                {
                    errors++;
                    errInfo.Append("第【" + (i + 1).ToString() + "】行【" + dtExcel.Columns[2].ColumnName + "】单元格不能为空<br/>");
                }
                else
                {
                    if (dtExcel.Rows[i][2].ToString() == "是")
                        objQ.Status = true;
                    else if (dtExcel.Rows[i][2].ToString() == "否")
                        objQ.Status = false;
                    else
                        objQ.Status = true;
                }

                objQ.Sort = 1;
                //if (string.IsNullOrEmpty(dtExcel.Rows[i][3].ToString().Trim()))
                //{
                //    objQ.Sort = 10;
                //}
                //else
                //{
                //    int result = 10;
                //    bool flag = int.TryParse(dtExcel.Rows[i][2].ToString(), out result);
                //    if (!flag)
                //    {
                //        errors++;
                //        errInfo.Append("第【" + (i + 1).ToString() + "】行【" + dtExcel.Columns[2].ColumnName + "】单元格输入有误<br/>");
                //    }
                //    else
                //        objQ.Sort = result;
                //}



                qList.Add(objQ);
            }
            if (errors > 0)
            {
                //有错，显示出错信息
                // divInfo.InnerHtml = errInfo.ToString();
                return errInfo.ToString();
            }
            else
            {
                List<Sys_Language> inserOrUpdateList = new List<Sys_Language>();
                foreach (Sys_Language obj in qList)
                {
                    //找到要修改的
                    List<Sys_Language> lanList = Sys_LanguageBLL.GetList("ZHName=N'" + obj.ZHName + "'");
                    if (lanList != null && lanList.Count > 0)
                    {
                        //看看是否是一样的，全部一样就不执行数据库操作
                        List<Sys_Language> lanList2 = lanList.Where(c => c.Status == obj.Status && c.ENName == obj.ENName).ToList();
                        if (lanList2 == null || lanList2.Count <= 0)//没有全部一样的，只是有ZHName一样，就修改
                        {
                            Sys_Language objForUpdate = lanList[0];
                            objForUpdate.UpdatedTime = DateTime.Now;
                            objForUpdate.ENName = obj.ENName;
                            objForUpdate.Sort = obj.Sort;
                            objForUpdate.Status = obj.Status;
                            objForUpdate.UpdatedBy = TModel.MID;
                            inserOrUpdateList.Add(objForUpdate);
                            updateCount++;
                        }
                    }
                    else
                    {
                        //新增加的
                        obj.Code = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "");
                        obj.CreatedBy = TModel.MID;
                        obj.CreatedTime = DateTime.Now;
                        inserOrUpdateList.Add(obj);
                        inserCount++;
                    }
                }
                Sys_LanguageBLL.SaveOrUpdate(inserOrUpdateList);
            }
            return "总行数:" + totalCount.ToString() + "，修改:" + updateCount.ToString() + "，新增:" + inserCount.ToString();
        }

    }
}