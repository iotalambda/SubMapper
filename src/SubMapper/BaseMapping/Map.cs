﻿using SubMapper.Metadata;
using System;
using System.Linq.Expressions;

namespace SubMapper
{
    public partial class BaseMapping<TA, TB>
    {
        public BaseMapping<TA, TB> Map<TValue>(
            Expression<Func<TA, TValue>> getSubAExpr,
            Expression<Func<TB, TValue>> getSubBExpr)
        { 
            var subAInfo = Utils.GetMapPropertyInfo(getSubAExpr);
            var subBInfo = Utils.GetMapPropertyInfo(getSubBExpr);

            var subMap = new SubMap
            {
                GetSubAFromA = a => subAInfo.Getter(a),
                GetSubBFromB = b => subBInfo.Getter(b),

                SetSubAFromA = (a, v) => { if (v == null) return; subAInfo.Setter(a, v); },
                SetSubBFromB = (b, v) => { if (v == null) return; subBInfo.Setter(b, v); },

                SubAPropertyInfo = subAInfo.PropertyInfo,
                SubBPropertyInfo = subBInfo.PropertyInfo,

                MetaMap = new Lazy<MetaMap>(() => new MetaMap
                {
                    MetadataType = typeof(BaseMapping.BaseMappingMetadata),
                    Metadata = new BaseMapping.BaseMappingMetadata
                    {
                        SuperAProperty = subAInfo.PropertyInfo,
                        SuperBProperty = subBInfo.PropertyInfo,
                        SubMetaMap = null
                    }
                }),

                SubAPropertyName = subAInfo.PropertyName,
                SubBPropertyName = subBInfo.PropertyName
            };

            _subMaps.Add(subMap);

            return this;
        }
    }
}
