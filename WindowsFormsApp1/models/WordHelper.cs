using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1.models
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;
        public WordHelper(string filename)
        {
            if(File.Exists(filename)) { _fileInfo = new FileInfo(filename); }
            else { throw new ArgumentException("File not found!"); }
        }    
        public void Process( Dictionary<string, string> dict )
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach(var word in dict)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = word.Key;
                    find.Replacement.Text = word.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, DateTime.Now.ToString("yyyyMMdd HHmmss") + _fileInfo.Name);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();

            }
            catch( Exception ex ) { MessageBox.Show(ex.Message); }
            finally
            {
                if (app != null) { app.Quit(); }
            }
        }
    }
}
