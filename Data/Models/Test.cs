﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class Test
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }

        [ForeignKey(nameof(AmbulatoryList))]
        public string AmbulatoryListId { get; set; }
        public AmbulatoryList AmbulatoryList { get; set; }

    }
}