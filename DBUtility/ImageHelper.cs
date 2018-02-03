using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DBUtility
{
    public class ImageHelper
    {
        public static string GetImageType(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string bx = " ";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                bx = buffer.ToString();
                buffer = r.ReadByte();
                bx += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            r.Close();
            fs.Close();

            return bx;
        }

        public static string GetImageType(Stream fs)
        {
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string bx = " ";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                bx = buffer.ToString();
                buffer = r.ReadByte();
                bx += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            //r.Close();
            //fb.Close();
            ////真实的文件类型
            //Console.WriteLine(bx);
            ////文件名，包括格式
            //Console.WriteLine(System.IO.Path.GetFileName(path));
            ////文件名， 不包括格式
            //Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(path));
            ////文件格式
            //Console.WriteLine(System.IO.Path.GetExtension(path));

            //Console.ReadLine();

            return bx;
        }
    }

    public enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        BMP = 6677,
        PNG = 13780,
        COM = 7790,
        EXE = 7790,
        DLL = 7790,
        RAR = 8297,
        ZIP = 8075,
        XML = 6063,
        HTML = 6033,
        ASPX = 239187,
        CS = 117115,
        JS = 119105,
        TXT = 210187,
        SQL = 255254,
        BAT = 64101,
        BTSEED = 10056,
        RDP = 255254,
        PSD = 5666,
        PDF = 3780,
        CHM = 7384,
        LOG = 70105,
        REG = 8269,
        HLP = 6395,
        DOC = 208207,
        XLS = 208207,
        DOCX = 208207,
        XLSX = 208207,
    }
}
