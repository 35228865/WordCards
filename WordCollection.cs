using System.Collections.ObjectModel;
using System.IO;

public class WordCollection : Collection<WordItem>
{
    public void LoadFromStringArray(string[] lines)
    {
        this.Clear();
        foreach (string line in lines)
        {
            WordItem item = new WordItem(line);
            this.Add(item);
        }
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (WordItem item in this)
            {
                writer.WriteLine(item.ToLineString());
            }
        }
    }
}