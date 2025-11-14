using System.Collections.Generic;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private static readonly Random _rnd = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(" ");
        foreach (string w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        
        // build list of indices of visible words
        var visibleIndices = _words
            .Select((w, i) => new { Word = w, Index = i })
            .Where(x => !x.Word.IsHidden())
            .Select(x => x.Index)
            .ToList();

        if (visibleIndices.Count == 0)
            return;

        for (int i = 0; i < numberToHide && visibleIndices.Count > 0; i++)
        {
            int pick = _rnd.Next(visibleIndices.Count);
            int indexToHide = visibleIndices[pick];
            _words[indexToHide].Hide();
            // remove that index so we don't hide the same word twice this call
            visibleIndices.RemoveAt(pick);
        }
    }
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();

        List<string> displayed = new List<string>();
        foreach (var word in _words)
        {
            displayed.Add(word.GetDisplayText());
        }

        return $"{referenceText}\n{string.Join(" ", displayed)}";
    }
    public bool IsCompletelyHidden()
    {
        foreach (var w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }

}