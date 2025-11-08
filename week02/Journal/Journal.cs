using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine(); 
        }
    }

    public void SaveToFile(string filename)
    {
        string sep = "~|~"; 
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                
                string safeText = entry._entryText.Replace(Environment.NewLine, "\\n");
                string line = $"{entry._date}{sep}{entry._promptText}{sep}{safeText}";
                writer.WriteLine(line);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string sep = "~|~";
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found: " + filename);
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        List<Entry> loaded = new List<Entry>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { sep }, StringSplitOptions.None);
            if (parts.Length >= 3)
            {
                Entry e = new Entry();
                e._date = parts[0];
                e._promptText = parts[1];
                e._entryText = parts[2].Replace("\\n", Environment.NewLine);
                loaded.Add(e);
            }
        }
        _entries = loaded; 
    }
}