using AutoMapper;
using GraduateThesis.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(configurationExpress =>
            {
                configurationExpress.AddProfile(typeof(MapProfile));
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper = lazy.Value;
    }
}
