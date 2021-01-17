using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenTK;

namespace RayTracing.World
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static ShouldSerializeContractResolver Instance { get; } = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);        
            if (typeof(Vector3).IsAssignableFrom(member.DeclaringType) && member.Name.Length > 1)
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}