using AutoMapper;

namespace Application.Common.Mappings
{
    public interface IAutoMap<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
            profile.CreateMap(GetType(), typeof(T));
        }
    }
}
