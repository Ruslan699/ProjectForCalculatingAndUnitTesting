using AutoMapper;

namespace AteshgahApp.UI.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Create(params Profile[] profiles)
        {
            return new MapperConfiguration(conf =>
            {
                if (profiles != null)
                    foreach (var item in profiles)
                        conf.AddProfile(item);

            }).CreateMapper();
        }
    }
}