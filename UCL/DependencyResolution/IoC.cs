using StructureMap;
using UCL.DependencyResolution;
using UCL.Models.Data;
namespace UCL {
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}