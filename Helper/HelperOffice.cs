using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Helper
{
    public static class HelperOffice
    {

        /// <summary>  
        /// Ecxel文件生成HTML并保存  
        /// </summary>  
        /// <param name="FilePath">需要生成的ecxel文件的路径</param>  
        /// <param name="saveFilePath">生成以后保存HTML文件的路径</param>  
        /// <returns>是否生成成功，成功为true，反之为false</returns>  
        public static bool GenerationExcelHTML(string FilePath, string saveFilePath)
        {
            try
            {
                Excel.Application app = new Excel.Application();
                app.Visible = false;
                Object o = Missing.Value;

                ///打开文件  
                /*下面是Microsoft Excel 9 Object Library的写法： */
                /*_Workbook xls = app.Workbooks.Open(FilePath, o, o, o, o, o, o, o, o, o, o, o, o);*/

                /*下面是Microsoft Excel 10 Object Library的写法： */
                _Workbook xls = app.Workbooks.Open(FilePath, o, o, o, o, o, o, o, o, o, o, o, o, o, o);

                ///转换格式，另存为 HTML  
                /*下面是Microsoft Excel 9 Object Library的写法： */
                /*xls.SaveAs(saveFilePath, Excel.XlFileFormat.xlHtml, o, o, o, o, XlSaveAsAccessMode.xlExclusive, o, o, o, o);*/

                /*下面是Microsoft Excel 10 Object Library的写法： */
                xls.SaveAs(saveFilePath, Excel.XlFileFormat.xlHtml, o, o, o, o, XlSaveAsAccessMode.xlExclusive, o, o, o, o, o);

                ///退出 Excel  
                app.Quit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //最后关闭打开的excel 进程  
                Process[] myProcesses = Process.GetProcessesByName("EXCEL");
                foreach (Process myProcess in myProcesses)
                {
                    myProcess.Kill();
                }
            }
        }

        /// <summary>  
        /// WinWord文件生成HTML并保存  
        /// </summary>  
        /// <param name="FilePath">需要生成的word文件的路径</param>  
        /// <param name="saveFilePath">生成以后保存HTML文件的路径</param>  
        /// <returns>是否生成成功，成功为true，反之为false</returns>  
        public static bool GenerationWordHTML(string FilePath, string saveFilePath)
        {
            try
            {
                Word.ApplicationClass word = new Word.ApplicationClass();
                Type wordType = word.GetType();
                Word.Documents docs = word.Documents;

                /// 打开文件   
                Type docsType = docs.GetType();
                Word.Document doc = (Word.Document)docsType.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { FilePath, true, true });

                /// 转换格式，另存为 HTML   
                Type docType = doc.GetType();

                /*下面是Microsoft Word 9 Object Library的写法： */
                /*docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { saveFilePath, Word.WdSaveFormat.wdFormatHTML });*/

                /*下面是Microsoft Word 10 Object Library的写法： */
                docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
                null, doc, new object[] { saveFilePath, Word.WdSaveFormat.wdFormatFilteredHTML });

                /// 退出 Word  
                wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //最后关闭打开的winword 进程  
                Process[] myProcesses = Process.GetProcessesByName("WINWORD");
                foreach (Process myProcess in myProcesses)
                {
                    myProcess.Kill();
                }
            }
        }
    }
}
