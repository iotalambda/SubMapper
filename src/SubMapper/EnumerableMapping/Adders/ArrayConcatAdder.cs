﻿using SubMapper.EnumerableMapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubMapper.EnumerableMapping.Adders
{
    public static partial class PartialEnumerableMappingExtensions
    {
        public static PartialEnumerableMapping<TSubA, TSubB, IEnumerable<TSubIItem>, TSubJ, TSubIItem>
            WithArrayConcatAdder<TSubA, TSubB, TSubJ, TSubIItem>(
            this PartialEnumerableMapping<TSubA, TSubB, IEnumerable<TSubIItem>, TSubJ, TSubIItem> source)
            where TSubJ : new()
            where TSubIItem : new()
        {
            source.WithAdder((bc, b) => (bc ?? new TSubIItem[] { }).Concat(new[] { b }).ToArray());
            return source;
        }
    }
}