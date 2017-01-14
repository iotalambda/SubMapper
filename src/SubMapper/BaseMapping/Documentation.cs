﻿using SubMapper.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubMapper
{
    public partial class BaseMapping<TA, TB>
    {
        // TODO:
        public string GetDocumentation()
            => string.Join(Environment.NewLine, _subMaps.Select(s => s.HalfSubMapPair.IHalfSubMap + " MAPS TO " + s.HalfSubMapPair.JHalfSubMap));
        
        public IEnumerable<MetaMap> MetaMaps => _subMaps.Select(s => s.MetaMap.Value);
    }
}