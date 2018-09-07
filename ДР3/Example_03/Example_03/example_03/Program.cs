﻿using System;
using Example_03.ClassicBuilders;
using Example_03.Enums;
using Example_03.FluentBuilders;
using Example_03.StateBuilders;

namespace Example_03
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //RunClassicBuilder();
            //RunCustomStringBuilder();
            //RunStateBuilder();
            //RunFormalStateBuilder();

            //RunBenchmark();

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void RunClassicBuilder()
        {
            var builders = new IClassicBuilder[] { new PdfClassicBuilder(), new XlsxClassicBuilder() };

            foreach (var builder in builders)
            {
                var director = new ClassicBuilderDirector(builder);
                director.Build("name_1", "text_1");
                var file = builder.Result;
                Console.WriteLine($"{file.Name} : {file.Text}");
            }
        }

        private static void RunCustomStringBuilder()
        {
            var stringBuilder = new CustomStringBuilder();

            stringBuilder.AppendLine("text_1");
            Console.WriteLine(stringBuilder.Result);

            stringBuilder.AppendLine("text_2")
                .AppendFormat("text_{0}", 3);
            Console.WriteLine(stringBuilder.Result);
        }

        private static void RunStateBuilder()
        {
            var lanch = new LunchBuilder()
                .AddEntree(EntreeType.Cutlet)
                .AddSideDish(SideDishType.Puree)
                .Build;            

            Console.WriteLine(lanch);

            var badLunch = new LunchBuilder.LunchSideDishBuilder(EntreeType.Cutlet)
                .AddSideDish(SideDishType.Pasta)
                .Build;
            Console.WriteLine(badLunch);
        }

        private static void RunFormalStateBuilder()
        {
            var lanch = new FormalLunchBuilder()
                .AddEntree(EntreeType.Steak)
                .AddSideDish(SideDishType.Pasta)
                .Build;

            Console.WriteLine(lanch);
        }


        private static void RunBenchmark()
        {
            const int repeats = 30000;

            BenckmarkBase(() =>
                {
                    var sb = new CustomStringBuilder();
                    for (var i = 0; i < repeats; i++)
                    {
                        sb.AppendLine("line");
                    }
                    var res = sb.Result;
                });

            BenckmarkBase(() =>
            {
                var osb = new OptimizedStringBuilder();
                for (var i = 0; i < repeats; i++)
                {
                    osb.AppendLine("line");
                }
                var res = osb.Result;
            });
        }

        private static void BenckmarkBase(Action action)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            action();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
