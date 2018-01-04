﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CountAsync
{
    public class WordCounter
    {
        public async Task<int> CountNonExistentWordsAsync()
        {
            Task<string> articleTask = new WebClient().DownloadStringTaskAsync(
                @"https://archive.org/stream/warandpeace030164mbp/warandpeace030164mbp_djvu.txt");
            Task<string> wordsTask = new WebClient().DownloadStringTaskAsync(
                @"https://github.com/dwyl/english-words");

            string article = await articleTask;
            string words = await wordsTask;

            HashSet<string> wordList = new HashSet<string>(words.Split('\n'));

            var nonExistentWords = 0;

            foreach (string word in article.Split('\n', ' '))
            {
                if (!wordList.Contains(word)) nonExistentWords++;
            }

            return nonExistentWords;
        }
    }
}
