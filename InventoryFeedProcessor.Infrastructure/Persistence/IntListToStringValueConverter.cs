﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryFeedProcessor.Infrastructure
{
    public class StringListToStringValueConverter : ValueConverter<List<string>, string>
    {
        public StringListToStringValueConverter() : base(le => ListToString(le), (s => StringToList(s)))
        {

        }
        public static string ListToString(List<string> value)
        {
            if (value == null || value.Count() == 0)
            {
                return null;
            }

            return string.Join(",",value);
        }

        public static List<string> StringToList(string value)
        {
            if (value == null || value == string.Empty)
            {
                return null;
            }

            return value.Split(',').ToList(); ;

        }
    }
}
