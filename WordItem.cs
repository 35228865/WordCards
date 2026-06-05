using System;
using System.Linq;

public class WordItem
{
    public string Word { get; set; }
    public string Phonogram { get; set; }
    public string SoundPath { get; set; }
    public string Explain { get; set; }

    public WordItem(string str)
    {
        string[] strLists = str.Split('\t');
        if (strLists.Length >= 3)
        {
            Word = strLists[0];
            Phonogram = strLists[1];
            SoundPath = strLists[2];
            Explain = string.Join(Environment.NewLine, strLists.Skip(3));
        }
    }

    public override string ToString()
    {
        return Word;
    }

    public string ToLineString()
    {
        // 將 Explain 屬性中的換行符號替換為\t，以便在字串中顯示。
        string strExplain = Explain.Replace(Environment.NewLine, "\t");
        // 將 WordItem 物件轉換為字串
        return $"{Word}\t{Phonogram}\t{SoundPath}\t{strExplain}";

    }
}