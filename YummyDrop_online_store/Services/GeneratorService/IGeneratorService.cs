﻿using YummyDrop_online_store.Models;

namespace YummyDrop_online_store.Services.GeneratorService
{
    public interface IGeneratorService
    {
        /// <summary>
        /// The method returns a shuffled list with the size equals 1_000_000. The list contains only ids.
        /// </summary>
        /// <param name="yummys">List of YummyItem</param>
        /// <returns>Shuffled list with 1_000_000 elements of ids</returns>
        public List<int> GenerateMillionIds(List<YummyItem> yummys);
    }
}