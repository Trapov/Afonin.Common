using System;
using System.Linq;

namespace Afonin.Common.PrototypeParadigm
{
    public static class Program
    {
        public static void Main()
        {
            dynamic car = Mercedec();

            dynamic myProxy = new Binder(Mercedec, () => new
            {
                GetCarName = new Func<string>(() => "NOT MERCEDEC"),
                GetTires = new Func<(string name, int count)[]>(() => new[]
                    {(name: "wheel", count: 2), (name: "bumper", count: 2)})
            });

            Console.WriteLine(car.ShowMe());
            Console.WriteLine(myProxy.ShowMe());
            Console.ReadLine();
        }

        private static object Car(string carName)
        {
            var tires = new[] {(name: "wheel", count: 2), (name: "bumper", count: 2)};
            var localCarName = carName;
            return new
            {
                GetCarName = new Func<string>(() => localCarName),
                GetTires = new Func<(string name, int count)[]>(() => tires),

                ShowMe = new Func<string>(() =>
                {
                    return
                        $"{localCarName} \n {string.Concat(tires.SelectMany(s => s.name.ToString() + ' ' + s.count.ToString() + ' '))}";
                })
            };
        }

        private static object Mercedec()
        {
            dynamic car = Car(nameof(Mercedec));
            return Binder.Merge(new
            {
                GetCarName = new Func<string>(() => car.GetCarName())
            }, car);
        }
    }
}