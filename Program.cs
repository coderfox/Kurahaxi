using System.Linq;
using Kurahaxi.Providers.Export;
using Kurahaxi.Providers.Import;

namespace Kurahaxi
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once ArrangeTypeModifiers
    class Program
    {
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            IImporter importer = new SampleDataImporter();
            var courses = importer.Import().ToArray();
            IExporter exporter = new ICalExporter(courses);
            exporter.Export();
            exporter = new ConsoleExporter(courses);
            exporter.Export();
        }
    }
}